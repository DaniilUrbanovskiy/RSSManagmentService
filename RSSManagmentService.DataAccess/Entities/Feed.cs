using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Entities
{
    public class Feed
    {
        [Key]
        public int Id { get; set; }

        public User User { get; set; }

        public string Url { get; set; }       
    }
}
