using System.Data.SqlClient;


namespace KSTDotNetCore.RestApi
{
    internal static class ConnectionStrings
    {
        public static SqlConnectionStringBuilder sqlConnectionStringBuilder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "KSTDotNet",
            UserID = "sa",
            Password = "sa@123",
            TrustServerCertificate = true
        };
    }
}
