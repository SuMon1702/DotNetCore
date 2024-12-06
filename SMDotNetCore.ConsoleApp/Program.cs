

using Microsoft.Data.SqlClient;
using System.Data;


Console.WriteLine("Hello, World!");
SqlConnectionStringBuilder stringBuilder = new SqlConnectionStringBuilder();
stringBuilder.DataSource = ".";
stringBuilder.InitialCatalog = "SMDotNetTrainingDB";
stringBuilder.UserID = "sa";
stringBuilder.Password = "sasa@123";
stringBuilder.TrustServerCertificate = true;
SqlConnection connection = new SqlConnection(stringBuilder.ConnectionString);

connection.Open();
Console.WriteLine("Connection opens");

string query = "Select * from Tbl_Movie";
SqlCommand cmd = new SqlCommand(query, connection);
SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
DataTable dt = new DataTable();
sqlDataAdapter.Fill(dt);


connection.Close();
Console.WriteLine("Connection closes");

foreach (DataRow dr in dt.Rows)
{
    Console.WriteLine("Movie ID=>" + dr["MovieID"]);
    Console.WriteLine("Movie Name=>" + dr["MovieName"]);
    Console.WriteLine("Movie Title=>" + dr["MovieTitle"]);
    Console.WriteLine("Movie Content=>" + dr["MovieContent"]);
    Console.WriteLine("........................");
}
Console.ReadKey();

