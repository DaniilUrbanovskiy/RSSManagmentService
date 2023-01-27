using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Entities
{
    public class News
    {
        [Key]
        public int Id { get; set; }

        public Feed Feed { get; set; }
      
        public string? Title { get; set; }
        
        public string? Description { get; set; }

        public string? SourceLink { get; set; }

        public DateTimeOffset? PublishedDate { get; set; }

        public bool IsRead { get; set; }
    }
}