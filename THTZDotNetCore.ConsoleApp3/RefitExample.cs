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

            var item2 = await blogApi.GetBlog(2);

            try
            {
                var item1 = await blogApi.GetBlog(1);

            }
            catch(ApiException ex)
            {
                if(ex.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("No data found.");
                }
            }

            var item3 = await blogApi.CreateBlog(new BlogModel
            {
                BlogTitle = "test",
                BlogAuthor = "test",
                BlogContent = "test",

            });
        }
    }
}
