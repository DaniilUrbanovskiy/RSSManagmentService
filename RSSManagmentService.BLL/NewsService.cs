using RSSManagmentService.DataAccess.Repository;
using RSSManagmentService.Entities;
using System.ServiceModel.Syndication;
using System.Xml;

namespace RSSManagmentService.BLL
{
    public class NewsService
    {
        private readonly NewsRepository _newsRepository;

        public NewsService(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task AddNewsFromFeedAsync(Feed feed)
        {
            var listNews = new List<News>();

            var reader = XmlReader.Create(feed.Url);
            var rssFeed = SyndicationFeed.Load(reader);
           
            foreach (var item in rssFeed.Items)
            {
                listNews.Add(
                new News
                {
                    Title = item.Title?.Text,
                    Description = item.Summary == null ? (item.Content as TextSyndicationContent)?.Text : item.Summary?.Text,
                    PublishedDate = item.PublishDate,
                    SourceLink = item.Links[0]?.Uri.AbsoluteUri,
                    Feed = feed,
                    IsRead = false
                });
            }

            reader.Close();

            await _newsRepository.AddRangeAsync(listNews);
        }

        public async Task<List<News>> GetUnreadNewsByDateAsync(DateTimeOffset dateFrom, User user)
        {
            return await _newsRepository.GetUnreadByDateAsync(dateFrom, user);
        }

        public async Task SetNewsAsReadAsync(List<int> newsIds, int userId)
        {
            var news = await _newsRepository.GetByIdsAsync(newsIds, userId);
            news.ForEach(x => x.IsRead = true);
            await _newsRepository.UpdateRangeAsync(news);
        }
    }
}
