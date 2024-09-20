// See https://aka.ms/new-console-template for more information
using System.Data;
using System.Data.SqlClient;
using THTZDotNetCore.ConsoleApp;

//Console.WriteLine("Hello, World!");
//Console.ReadLine();
//Console.ReadKey();

//md => markdown


AdoDotNet adoDotNet = new AdoDotNet();
//adoDotNet.Read();
//adoDotNet.Create();
//adoDotNet.Edit();
//adoDotNet.Update();
adoDotNet.Delete();



Console.ReadKey();