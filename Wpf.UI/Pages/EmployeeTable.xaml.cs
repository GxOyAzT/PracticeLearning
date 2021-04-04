using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wpf.DataAccess.Repos.Employee;

namespace Wpf.UI.Pages
{
    public partial class EmployeeTable : Page
    {
        private readonly IEmployeeRepo _employeeRepo;

        public EmployeeTable(
            IEmployeeRepo employeeRepo)
        {
            InitializeComponent();
            _employeeRepo = employeeRepo;

            List<object> rowEmployee = new List<object>();

            foreach (var item in _employeeRepo.GetIds())
            {
                EmployeeRow employeeRow = new EmployeeRow(employeeRepo);
                employeeRow.SetEmployeeId(item);
                rowEmployee.Add(new { Row = employeeRow });
            }

            ListEmployee.ItemsSource = rowEmployee;
        }
    }
}
