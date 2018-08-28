using LNF.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using YokogawaService.Models;
using Meter = LNF.Repository.Meter;

namespace Meters.Controllers.Api
{
    public class ReportController : ApiController
    {
        [HttpPost, Route("api/report/run/{type}")]
        public ReportModel RunReport([FromBody] DataQueryCriteria criteria, [FromUri] string type)
        {
            if (criteria == null)
                throw new Exception("Criteria is required.");

            if (!criteria.StartDate.HasValue)
                throw new Exception("Criteria must have a StartDate value.");

            if (!criteria.EndDate.HasValue)
                throw new Exception("Criteria must have a EndDate value.");

            if (criteria.StartDate.Value >= criteria.EndDate.Value)
                throw new Exception("Criteria must have a StartDate that comes before the EndDate.");

            IList<Meter.MeterData> meterData = QueryMeterData(criteria)
                .Where(x => x.TimeStamp.Day == criteria.StartDate.Value.Day && x.TimeStamp.Hour == criteria.StartDate.Value.Hour && x.TimeStamp.Minute == criteria.StartDate.Value.Minute && x.TimeStamp.Second == criteria.StartDate.Value.Second).ToList();

            IList<Meter.MeterReport> reports;

            if (type != "all")
                reports = GetReports().Where(x => x.ReportType == type).ToList();
            else
                reports = GetReports().ToList();

            var datasets = new List<ReportDataset>();

            var labels = new List<string>();
            var d = criteria.StartDate.Value;

            // We must use d <= EndDate because we are only using the value recorded on the first
            // day of the month at midnight. So to run the report through Aug 2018 we need to include the
            // value on 2018-09-01 since this is the total usage through the end of August.

            while (d <= criteria.EndDate.Value)
            {
                labels.Add(d.ToString("MMM \\'yy"));

                foreach (var rep in reports)
                {
                    ReportDataset ds = datasets.FirstOrDefault(x => x.Label == rep.ReportName);

                    if (ds == null)
                    {
                        ds = new ReportDataset()
                        {
                            Label = rep.ReportName,
                            Data = new List<double>(),
                            BorderColor = rep.BorderColor,
                            BackgroundColor = rep.BackgroundColor,
                            PointBorderColor = rep.PointBorderColor,
                            PointBackgroundColor = rep.PointBackgroundColor,
                            UnitCost = rep.UnitCost,
                            Fill = false
                        };

                        datasets.Add(ds);
                    }

                    var md = meterData.FirstOrDefault(x => x.TimeStamp == d && x.Header == rep.Header);
                    var value = md == null ? 0 : md.Value;
                    ds.Data.Add(value);
                }

                d = d.AddMonths(1);
            }


            var result = new ReportModel()
            {
                Labels = labels,
                Datasets = datasets.Where(x => x.Data.Sum() > 0)
            };

            return result;
        }

        private IQueryable<Meter.MeterReport> GetReports()
        {
            return DA.Current.Query<Meter.MeterReport>();
        }

        private IQueryable<Meter.MeterData> QueryMeterData(DataQueryCriteria criteria)
        {
            var result = DA.Current.Query<Meter.MeterData>();

            if (criteria != null)
            {
                if (!string.IsNullOrEmpty(criteria.HeaderPattern))
                    result = result.Where(x => x.Header.Contains(criteria.HeaderPattern));

                if (criteria.StartDate.HasValue)
                    result = result.Where(x => x.TimeStamp >= criteria.StartDate.Value);

                // We must use TimeStamp <= EndDate because we are only using the value recorded on the first
                // day of the month at midnight. So to run the report through Aug 2018 we need to include the
                // value on 2018-09-01 since this is the total usage through the end of August.

                if (criteria.EndDate.HasValue)
                    result = result.Where(x => x.TimeStamp <= criteria.EndDate.Value);
            }

            return result;
        }
    }
}
