using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SMDotNetCore.ConsoleApp
{
    internal class AdoDotNetExample
    {

        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "SMDotNetTrainingDB",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };
        public void Read()
    {
            
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

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
        }

        public void Create(string name, string title, string content)
        {
                SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();
            string query = @"INSERT INTO [dbo].[Tbl_Movie]
           ([MovieName]
           ,[MovieTitle]
           ,[MovieContent])
     VALUES
           (@MovieName
           ,@MovieTitle
           ,@MovieContent)";
            SqlCommand cmd= new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieName",name);
            cmd.Parameters.AddWithValue("@MovieTitle",title);
            cmd.Parameters.AddWithValue ("@MovieContent",content);
           int result= cmd.ExecuteNonQuery();


            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }
    }
}
