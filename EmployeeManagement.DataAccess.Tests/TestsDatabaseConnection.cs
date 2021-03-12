namespace EmployeeManagement.DataAccess.Tests
{
    public class TestsDatabaseConnection
    {
        public static string GetConnection() => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagamentTests;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
