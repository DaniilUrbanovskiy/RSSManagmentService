using RSSManagmentService.Entities;

namespace RSSManagmentService.DataAccess.Repository
{
    public class FeedUrlRepository
    {
        private readonly SqlContext _context;

        public FeedUrlRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task Add(FeedUrl feedUrl)
        {
            await _context.FeedUrls.AddAsync(feedUrl);
            await _context.SaveChangesAsync();
        }
    }
}
