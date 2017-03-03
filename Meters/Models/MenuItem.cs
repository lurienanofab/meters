namespace Meters.Models
{
    public class MenuItem
    {
        public string Text { get; set; }
        public string Url { get; set; }
        public string Tag { get; set; }
        public bool Visible { get; set; }

        public string GetCssClass(string currentTag)
        {
            return Tag == currentTag ? "active" : string.Empty;
        }
    }
}