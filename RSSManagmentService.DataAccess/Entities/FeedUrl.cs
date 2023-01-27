using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Entities
{
    public class FeedUrl
    {
        [Key]
        public int Id { get; set; }

        public string Url { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
