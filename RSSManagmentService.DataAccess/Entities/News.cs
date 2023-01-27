using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public FeedUrl FeedUrl { get; set; }

        public bool IsReaded { get; set; }

        public DateTimeOffset PublishedDate { get; set; }

        public string Title { get; set; }

        public string Link { get; set; }

        public string Description { get; set; }
    }
}
