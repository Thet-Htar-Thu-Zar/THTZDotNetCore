﻿// See https://aka.ms/new-console-template for more information
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

//DapperExample dapper = new DapperExample();
//dapper.Read();
//dapper.Create("Real", "Chaw", "C#");
//dapper.Edit(1);
//dapper.Update(1, "Real", "Thet", "C#");
//dapper.Delete(3);

EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Read();
//eFCoreExample.Create("Real", "Chaw", "C#");
//eFCoreExample.Edit(1);
//eFCoreExample.Update(1, "Real", "Thet", "C#");
eFCoreExample.Delete(3);

Console.ReadKey();