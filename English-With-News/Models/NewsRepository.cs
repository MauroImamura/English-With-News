using English_With_News.Models.Interfaces;

namespace English_With_News.Models
{
    public class NewsRepository : INewsRepository
    {
        public IEnumerable<News> CreateNewsList()
        {
            //Write method for binding app to rss sources
            throw new NotImplementedException();
        }
    }
}
