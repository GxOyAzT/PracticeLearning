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
using Wpf.DataAccess.Processor;
using Wpf.UI.Pages;

namespace Wpf.UI
{
    public partial class MainWindow : Window
    {
        private readonly IDisplayHello _displayHello;
        private readonly EmployeeTable _employeeTable;

        public MainWindow(IDisplayHello displayHello, EmployeeTable employeeTable)
        {
            InitializeComponent();
            _displayHello = displayHello;
            _employeeTable = employeeTable;
        }

        private void Click_Employees(object sender, RoutedEventArgs e)
        { 
            AppFrame.Content = _employeeTable;
        }
    }
}
