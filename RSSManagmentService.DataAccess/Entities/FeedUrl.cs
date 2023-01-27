using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Entities
{
    public class FeedUrl
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public User User { get; set; }
    }
}
