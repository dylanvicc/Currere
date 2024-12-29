namespace Currere.Shared.Objects
{
    public sealed class Post
    {
        public int PostID { get; set; }

        public int UserID { get; set; }

        public string Title { get; set; } = string.Empty;

        public string TextContent { get; set; } = string.Empty;

        public DateTime CreationDateUTC { get; set; }

        public int TimesFlagged { get; set; }

        public int DisplayPriority { get; set; }
    }
}
