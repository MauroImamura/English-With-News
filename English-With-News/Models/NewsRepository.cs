﻿using English_With_News.Models.Interfaces;
using System.Net.Http.Headers;
using System.ServiceModel.Syndication;
using System.Xml;

namespace English_With_News.Models
{
    public class NewsRepository : INewsRepository
    {
        public IEnumerable<News> CreateNewsList()
        {
            //Source List
            IList<string> sources = new List<string>();

            sources.Add("http://rss.cnn.com/rss/cnn_latest.rss"); //CNN
            sources.Add("http://feeds.bbci.co.uk/news/rss.xml"); //BBC
            sources.Add("https://news.un.org/feed/subscribe/en/news/all/rss.xml"); //UN

            //XML reading and news list composition
            IList<News> newsList = new List<News>();

            foreach(string source in sources)
            {
                
                XmlReader reader = XmlReader.Create(source);
                SyndicationFeed feed = SyndicationFeed.Load(reader);
                reader.Close();
                foreach (SyndicationItem item in feed.Items)
                {
                    News news = new News();
                    
                    news.headline = item.Title.Text;
                    news.summmary = item.Summary.Text;
                    news.link = item.Id;
                    news.publish = item.PublishDate.DateTime;
                    
                    newsList.Add(news);
                }
            }

            return newsList;
        }

        public async Task<string> Meaning(string word)
        {

            HttpClient client = new HttpClient();

            string entry = word.Replace(",", "").Replace(".", "").Replace("'s", "").Replace("s'","").Replace("'","").Replace(":","");

            Uri baseLink = new Uri($"https://api.dictionaryapi.dev/api/v2/entries/en/{entry}");
            HttpResponseMessage response = await client.GetAsync(baseLink);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return responseBody;

        }
    }

}
