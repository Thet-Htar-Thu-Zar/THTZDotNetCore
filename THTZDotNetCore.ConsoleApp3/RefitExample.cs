using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace THTZDotNetCore.ConsoleApp3
{
    public class RefitExample
    {
        public async Task Run()
        {
            var blogApi = RestService.For<IBlogApi>("https://localhost:7212");
            var lst = await blogApi.GetBlogs();
            foreach(var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
            }
        }
    }
}
