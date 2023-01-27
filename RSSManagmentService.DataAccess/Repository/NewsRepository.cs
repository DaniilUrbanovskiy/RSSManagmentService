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
    }
}
