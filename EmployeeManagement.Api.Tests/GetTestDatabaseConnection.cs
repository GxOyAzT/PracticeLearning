namespace EmployeeManagement.Api.Tests
{
    public static class GetTestDatabaseConnection
    {
        public static string GetConnection() => @"Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=EmployeeManagamentTests;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
    }
}
