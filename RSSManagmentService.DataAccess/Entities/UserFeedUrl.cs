using System.ComponentModel.DataAnnotations;

namespace RSSManagmentService.Entities
{
    public class UserFeedUrl
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }

        public int FeedUrlId { get; set; }

        public UserFeedUrl(int userId, int urlId)
        {
            this.UserId = userId;
            this.FeedUrlId = urlId;
        }
    }
}
