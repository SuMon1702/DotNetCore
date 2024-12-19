

using Microsoft.Data.SqlClient;
using SMDotNetCore.ConsoleApp;


//Console.WriteLine("Hello, World!");

AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
// adoDotNetExample.Create("name", "title", "content");
// adoDotNetExample.Update(13, "Rose", "Action", "Fighting");
// adoDotNetExample.Delete(13);
// adoDotNetExample.Delete(14);
// adoDotNetExample.Edit(14);
// adoDotNetExample.Edit(1);

//DapperExamples dapperExamples = new DapperExamples();
//dapperExamples.Run();

EFCoreExamples eFCoreExamples = new EFCoreExamples();
eFCoreExamples.Run();