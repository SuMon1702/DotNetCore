﻿using Microsoft.Data.SqlClient;

namespace SMDotNetCore.RestApiWithNLayer
{
    internal static class ConnectionString
    {
        public static SqlConnectionStringBuilder SqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "SMDotNetTrainingDB",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true,
        };
    }
}