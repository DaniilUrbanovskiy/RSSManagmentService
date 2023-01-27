using RSSManagmentService.DataAccess.Repository;
using RSSManagmentService.Entities;

namespace RSSManagmentService.BLL
{
    public class FeedUrlService
    {
        private readonly FeedUrlRepository _feedUrlRepository;

        public FeedUrlService(FeedUrlRepository feedUrlRepository)
        {
            _feedUrlRepository = feedUrlRepository;
        }

        public async Task<FeedUrl> AddFeedUrlAsync(FeedUrl feedUrl)
        {
            return await _feedUrlRepository.AddAsync(feedUrl);
        }
    }
}
