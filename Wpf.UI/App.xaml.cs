using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Windows;
using Wpf.DataAccess.DataAccess;
using Wpf.DataAccess.Processor;
using Wpf.DataAccess.Repos;
using Wpf.DataAccess.Repos.Employee;
using Wpf.DataAccess.Tables;
using Wpf.UI.Pages;

namespace Wpf.UI
{
    public partial class App : Application
    {
        public IServiceProvider ServiceProvider { get; private set; }

        void Start(object sender, StartupEventArgs e)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            ServiceProvider = serviceCollection.BuildServiceProvider();

            MainWindow mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
            mainWindow.Show();
        }

        private void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AaDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));

            services.AddScoped<IDisplayHello, DisplayHello>();

            services.AddTransient<IEmployeeRepo, EmployeeRepo>();
            services.AddTransient<IBaseRepo<EmployeeModel>, BaseRepo<EmployeeModel>>();

            services.AddTransient(typeof(MainWindow));
            services.AddTransient(typeof(EmployeeTable));
            services.AddTransient(typeof(EmployeeRow));
        }
    }
}
