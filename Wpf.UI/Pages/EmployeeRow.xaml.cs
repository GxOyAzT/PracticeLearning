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
using Wpf.DataAccess.Tables;

namespace Wpf.UI.Pages
{
    public partial class EmployeeRow : Page
    {
        private Guid EmployeeId;
        private readonly IEmployeeRepo employeeRepo;
        private EmployeeModel Employee { get; set; }

        public EmployeeRow(IEmployeeRepo employeeRepo)
        {
            InitializeComponent();
            this.employeeRepo = employeeRepo;
            EmployeeId = Guid.Empty;
        }

        public void SetEmployeeId(Guid id)
        {
            if (EmployeeId == Guid.Empty)
            {
                EmployeeId = id;
                Employee = employeeRepo.Get(EmployeeId);
                SetPage();
            }
        }

        private void SetPage()
        {
            LabelName.Content = Employee.Name;
        }

        private void Click_Show(object sender, RoutedEventArgs e)
        {
            this.Height = 40;
        }

        private void Click_Delete(object sender, RoutedEventArgs e)
        {
            MessageBox.Show($"DELETE {EmployeeId}");
        }
    }
}
