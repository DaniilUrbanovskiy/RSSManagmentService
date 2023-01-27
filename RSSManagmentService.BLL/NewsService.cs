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

        public async Task AddNewsFromFeedUrlAsync(News baseInfo)
        {
            var listNews = new List<News>();

            XmlReader reader = XmlReader.Create(baseInfo.FeedUrl.Url);
            SyndicationFeed feed = SyndicationFeed.Load(reader);
            reader.Close();

            foreach (var item in feed.Items)
            {
                listNews.Add(
                new News
                {
                    Title = item.Title.Text,
                    Description = item.Summary.Text,
                    PublishedDate = item.PublishDate,
                    Link = item.Id,
                    FeedUrl = baseInfo.FeedUrl,
                    IsReaded = baseInfo.IsReaded
                });
            }

            await _newsRepository.AddRangeAsync(listNews);
        }
    }
}
