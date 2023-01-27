using RSSManagmentService.Entities;

namespace RSSManagmentService.DataAccess.Repository
{
    public class UserFeedUrlRepository
    {
        private readonly SqlContext _context;

        public UserFeedUrlRepository(SqlContext context)
        {
            _context = context;
        }

        public async Task Add(UserFeedUrl userFeedUrl)
        {
            await _context.UserFeedUrls.AddAsync(userFeedUrl);
            await _context.SaveChangesAsync();
        }
    }
}
