// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");

using THTZDotNetCore.ConsoleApp3;

Console.WriteLine("waiting for api...");
Console.ReadLine();

RefitExample refitExample = new RefitExample();

await refitExample.Run();

Console.ReadLine();

