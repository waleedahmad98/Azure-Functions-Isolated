using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsolatedFunctionApp.Model;

namespace IsolatedFunctionApp.Data
{
    public class Data : IData
    {
        private List<NewsModel> _news = new();

        public Data()
        {
            _news.Add(new NewsModel { title = "News 1", content = "This is News 1" });
        }

        public NewsModel addNews(string title, string content)
        {
            NewsModel temp = new() { title = title, content = content };
            _news.Add(temp);
            return temp;
        }

        public List<NewsModel> getNewsList()
        {
            return _news;
        }

    }
}
