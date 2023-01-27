using Microsoft.EntityFrameworkCore;
using RSSManagmentService.Entities;

namespace RSSManagmentService.DataAccess.Repository
{
    public class NewsRepository
    {
        private readonly SqlContext _context;

        public NewsRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task AddRangeAsync(List<News> news)
        {
            await _context.News.AddRangeAsync(news);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRangeAsync(List<News> news)
        {
            _context.News.UpdateRange(news);
            await _context.SaveChangesAsync();
        }

        public async Task<List<News>> GetUnreadByDateAsync(DateTimeOffset dateFrom, User user)
        {
            return await _context.News.Include(x => x.Feed).Where(x => x.PublishedDate > dateFrom && x.Feed.User.Id == user.Id && !x.IsRead).ToListAsync();
        }

        public async Task<List<News>> GetByIdsAsync(List<int> ids, int userId)
        {
            return await _context.News.Where(x => ids.Contains(x.Id) && x.Feed.User.Id == userId).ToListAsync();
        }
    }
}
