using Microsoft.EntityFrameworkCore;
using RSSManagmentService.Entities;

namespace RSSManagmentService.DataAccess.Repository
{
    public class FeedRepository
    {
        private readonly SqlContext _context;

        public FeedRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Feed feed)
        {
            await _context.Feeds.AddAsync(feed);
        }

        public async Task<bool> IsExistAsync(Feed feed)
        {
            return await _context.Feeds.AnyAsync(x => x.User.Id == feed.User.Id && x.Url == feed.Url);
        }

        public async Task<List<Feed>> GetAsync(User user)
        {
            return await _context.Feeds.Where(x => x.User == user).ToListAsync();
        }
    }
}
