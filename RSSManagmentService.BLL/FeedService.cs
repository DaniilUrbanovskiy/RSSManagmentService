using RSSManagmentService.DataAccess.Repository;
using RSSManagmentService.Entities;
using System.Data;

namespace RSSManagmentService.BLL
{
    public class FeedService
    {
        private readonly FeedRepository _feedRepository;

        public FeedService(FeedRepository feedRepository)
        {
            _feedRepository = feedRepository;
        }

        public async Task AddFeedAsync(Feed feed)
        {
            var exist = await _feedRepository.IsExistAsync(feed);

            if (exist)
            {
                throw new DuplicateNameException();
            }

            await _feedRepository.AddAsync(feed);
        }

        public async Task<List<Feed>> GetFeedsAsync(User user)
        {
            return await _feedRepository.GetAsync(user);
        }
    }
}
