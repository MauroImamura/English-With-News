namespace English_With_News.Models
{
    public class News
    {
        public string headline { get; set; }

        public string summmary { get; set; }

        public IEnumerable<string> tags { get; set; }

        public string source { get; set; }
    }

    public class NewsList
    {
        public IEnumerable<News> News { get; set; }
    }
}
