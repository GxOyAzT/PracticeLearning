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
                db.EmployeeModels.RemoveRange(db.EmployeeModels.ToList());
                db.Deparemtnt.RemoveRange(db.Deparemtnt.ToList());

                db.Deparemtnt.AddRange(_hardcodedData.GetDepartments());
                db.EmployeeModels.AddRange(_hardcodedData.GetEmployees());

                db.SaveChanges();
            }
        }
    }
}
