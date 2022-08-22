namespace English_With_News.Models
{
    public class News
    {
        public string headline { get; set; }

        public string summmary { get; set; }

        public DateTime publish { get; set; }

        public string link { get; set; }
    }

    public class NewsList
    {
        public IEnumerable<News> currentNews { get; set; }
    }
}
