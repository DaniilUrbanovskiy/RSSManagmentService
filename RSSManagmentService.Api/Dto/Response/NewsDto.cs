namespace RSSManagmentService.Api.Dto.Response
{
    public class NewsDto
    {
        public int Id { get; set; }

        public string FeedUrl { get; set; }

        public bool IsRead { get; set; }

        public DateTimeOffset? PublishedDate { get; set; }

        public string? Title { get; set; }

        public string? SourceLink { get; set; }

        public string? Description { get; set; }
    }
}
