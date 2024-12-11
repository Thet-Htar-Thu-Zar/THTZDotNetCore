// See https://aka.ms/new-console-template for more information
using THTZDotNetCore.ConsoleApp3;

//Console.WriteLine("Hello, World!");

//HttpClient client = new HttpClient();
//var response = await client.GetAsync("https://jsonplaceholder.typicode.com/posts");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    Console.WriteLine(jsonStr);
//}

//get
//post
//put
//patch
//delete

//HttpClientExample httpClientExample = new HttpClientExample();
//await httpClientExample.Read();
//await httpClientExample.Edit(2);

//await httpClientExample.Create("test title", "test body", 3);
//await httpClientExample.Update("test title", "test body", 5);

RestClientExample restClientExample = new RestClientExample();
await restClientExample.Read();


//Console.WriteLine("waiting for api...");
//Console.ReadLine();

//RefitExample refitExample = new RefitExample();

//await refitExample.Run();

//Console.ReadLine();

