

using Microsoft.Data.SqlClient;
using SMDotNetCore.ConsoleApp;
using System.Data;


Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
adoDotNetExample.Read();
adoDotNetExample.Create("name", "title", "content");