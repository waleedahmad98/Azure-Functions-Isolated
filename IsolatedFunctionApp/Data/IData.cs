using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IsolatedFunctionApp.Model;

namespace IsolatedFunctionApp.Data
{
    public interface IData
    {
        NewsModel addNews(string title, string content);
        List<NewsModel> getNewsList();
    }
}
