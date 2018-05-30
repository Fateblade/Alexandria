namespace Alexandrian.Base.Models
{
    public enum LinkType { Undefined, Website, Document }

    public class Link
    {
        public LinkType Type { get; set; }
        public string Path { get; set; }
        public string Description { get; set; }
    }
}
