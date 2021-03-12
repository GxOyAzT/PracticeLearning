using EmployeeManagement.DataAccess;
using EmployeeManagement.TestsMockData;
using System;

namespace EmployeeManagement.ConsoleHelper
{
    class Program
    {
        static void Main(string[] args)
        {
            var data = new HardcodedDataV3();

            var initializeProcessor = new ResetDatabaseProcessor(data);

            initializeProcessor.Reset();

            using (var db = new ApplicationDataContext())
            {
                db.AddressModels.Add(new DataModel.AddressModel()
                {
                    Id = Guid.Parse("f0366d53-5b79-4773-9344-436b6d5f6aaf"),
                    City = "City-Employee-A",
                    Street = "Street-Employee-A",
                    ZipCode = "01-001",
                    EmployeeModelId = Guid.Parse("cbb00d49-c991-4964-86d4-92ff7c25a07b") // Emp A
                });

                db.SaveChanges();
            }
        }
    }
}
