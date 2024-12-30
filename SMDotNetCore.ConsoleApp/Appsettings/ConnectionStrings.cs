using Microsoft.Data.SqlClient;

namespace SMDotNetCore.ConsoleApp.Appsettings;

internal static class ConnectionStrings
{
    public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
    {
        DataSource = ".",
        InitialCatalog = "SMDotNetTrainingDB",
        UserID = "sa",
        Password = "sasa@123",
        TrustServerCertificate = true
    };
}
