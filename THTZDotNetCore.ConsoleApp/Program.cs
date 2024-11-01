// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THTZDotNetCore.ConsoleApp;

//Console.WriteLine("Hello, World!");
//Console.ReadLine();
//Console.ReadKey();

//md => markdown


//AdoDotNet adoDotNet = new AdoDotNet();
//adoDotNet.Read();
//adoDotNet.Create();
//adoDotNet.Edit();
//adoDotNet.Update();
//adoDotNet.Delete();

//AdoDotNet2 adoDotNet = new AdoDotNet2();
//adoDotNet.Read();
//adoDotNet.Edit();
//adoDotNet.Create();
//adoDotNet.Update();
//adoDotNet.Delete();

//DapperExample dapper = new DapperExample();
//dapper.Read();
//dapper.Create("Real", "Chaw", "C#");
//dapper.Edit(1);
//dapper.Update(1, "Real", "Thet", "C#");
//dapper.Delete(3);

DapperExample2 dapper = new DapperExample2();
//dapper.Read();
//dapper.Create("Imagine", "Chaw", "Java");
dapper.Edit(1);
//dapper.Update(1, "Real", "Thet", "C#");
//dapper.Delete(3);


//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("Real", "Chaw", "C#");
//eFCoreExample.Edit(1);
//eFCoreExample.Update(1, "Real", "Thet", "C#");
//eFCoreExample.Delete(3);

Console.ReadKey();
