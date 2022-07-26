namespace English_With_News.Models.Interfaces
{
    public interface INewsRepository
    {
        public IEnumerable<News> CreateNewsList();
    }
}
