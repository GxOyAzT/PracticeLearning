using EmployeeManagement.DataAccess;
using System.Linq;

namespace EmployeeManagement.TestsMockData
{
    public class ResetDatabaseProcessor
    {
        private readonly IHardcodedData _hardcodedData;

        public ResetDatabaseProcessor(IHardcodedData hardcodedData)
        {
            _hardcodedData = hardcodedData;
        }

        public void Reset()
        {
            using (var db = new ApplicationDataContext())
            {
                db.AddressModels.RemoveRange(db.AddressModels.ToList());
                db.EmployeeModels.RemoveRange(db.EmployeeModels.ToList());
                db.Departments.RemoveRange(db.Departments.ToList());
                db.SaveChanges();

                db.Departments.AddRange(_hardcodedData.GetDepartments());
                db.SaveChanges();
                db.EmployeeModels.AddRange(_hardcodedData.GetEmployees());
                db.SaveChanges();
                db.AddressModels.AddRange(_hardcodedData.GetAddressModels());
                db.SaveChanges();
            }
        }
    }
}
