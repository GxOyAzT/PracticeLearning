using EmployeeManagement.DataAccess;
using System.Linq;

namespace EmployeeManagement.TestsMockData
{
    public class ResetDatabaseProcessor
    {
        private readonly IHardcodedData _hardcodedData;
        private readonly ApplicationDataContext _context;

        public ResetDatabaseProcessor(IHardcodedData hardcodedData, ApplicationDataContext context)
        {
            _hardcodedData = hardcodedData;
            _context = context;
        }

        public void Reset()
        {
            _context.AddressModels.RemoveRange(_context.AddressModels.ToList());
            _context.EmployeeModels.RemoveRange(_context.EmployeeModels.ToList());
            _context.Departments.RemoveRange(_context.Departments.ToList());
            _context.SaveChanges();

            _context.Departments.AddRange(_hardcodedData.GetDepartments());
            _context.SaveChanges();
            _context.EmployeeModels.AddRange(_hardcodedData.GetEmployees());
            _context.SaveChanges();
            _context.AddressModels.AddRange(_hardcodedData.GetAddressModels());
            _context.SaveChanges();
        }
    }
}
