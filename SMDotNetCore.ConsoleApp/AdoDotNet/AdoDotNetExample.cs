using System.Data;
using Microsoft.Data.SqlClient;


namespace SMDotNetCore.ConsoleApp.AdoDotNet
{
    internal class AdoDotNetExample
    {

        private SqlConnectionStringBuilder _sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
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
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieName", name);
            cmd.Parameters.AddWithValue("@MovieTitle", title);
            cmd.Parameters.AddWithValue("@MovieContent", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Saving Successful." : "Saving Failed.";
            Console.WriteLine(message);
        }

        public void Update(int id, string name, string title, string content)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"UPDATE [dbo].[Tbl_Movie]
   SET [MovieName] = @MovieName
      ,[MovieTitle] = @MovieTitle
      ,[MovieContent] = @MovieContent
 WHERE MovieID= @MovieID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", id);
            cmd.Parameters.AddWithValue("@MovieName", name);
            cmd.Parameters.AddWithValue("@MovieTitle", title);
            cmd.Parameters.AddWithValue("@MovieContent", content);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            connection.Open();

            string query = @"DELETE FROM [dbo].[Tbl_Movie]
      WHERE MovieID=@MovieID;";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", id);
            int result = cmd.ExecuteNonQuery();

            connection.Close();
            string message = result > 0 ? "Delete Successful." : "Delete Failed.";
            Console.WriteLine(message);
        }

        public void Edit(int id)
        {
            SqlConnection connection = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);

            connection.Open();
            Console.WriteLine("Connection opens");

            string query = "Select * from Tbl_Movie Where MovieID= @MovieID";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@MovieID", id);
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sqlDataAdapter.Fill(dt);
            connection.Close();

            if (dt.Rows.Count == 0)
            {
                Console.WriteLine("No data found");
                return;
            }
            DataRow dr = dt.Rows[0];

            Console.WriteLine("Movie ID=>" + dr["MovieID"]);
            Console.WriteLine("Movie Name=>" + dr["MovieName"]);
            Console.WriteLine("Movie Title=>" + dr["MovieTitle"]);
            Console.WriteLine("Movie Content=>" + dr["MovieContent"]);
            Console.WriteLine("........................");
        }

    }


}
