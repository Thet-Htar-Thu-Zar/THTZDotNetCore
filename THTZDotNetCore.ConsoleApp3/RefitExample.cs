using Refit;

namespace THTZDotNetCore.ConsoleApp3
{
    public class RefitExample
    {
        public async Task Run()
        {
            var blogApi = RestService.For<IBlogApi>("https://localhost:7151");
            var lst = await blogApi.GetBlogs();
            foreach(var item in lst)
            {
                Console.WriteLine(item.BlogTitle);
            }
        }
    }
}
