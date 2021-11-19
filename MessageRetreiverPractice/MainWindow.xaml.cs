using MessageRetreiverPractice.DataAccess;
using MessageRetreiverPractice.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace MessageRetreiverPractice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<MessageModel> MessageModels { get; set; } //= new List<MessageModel>()
        //{
        //    new MessageModel()
        //    {
        //        Id = Guid.NewGuid(),
        //        WasSeen = false,
        //        Message = "Message 1"
        //    },
        //    new MessageModel()
        //    {
        //        Id = Guid.NewGuid(),
        //        WasSeen = true,
        //        Message = "Message 2"
        //    }
        //};

        AppDbContext _appDbContext { get; set; }

        public MainWindow()
        {
            _appDbContext = new AppDbContext(new DbContextOptionsBuilder().UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MessageRetreiver;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False").Options);
            InitializeComponent();
            ListV.ItemsSource = MessageModels;
            RetreiveMessagesService();
        }

        async Task RetreiveMessagesService()
        {
            Task.Run(() =>
            {
                for (; ; )
                {
                    MessageModels = _appDbContext.Messages.ToList();
                    Dispatcher.Invoke(() =>
                    {
                        ListV.ItemsSource = MessageModels;
                        ListV.Items.Refresh();
                    });
                    Thread.Sleep(1000 * 2);
                }
            });
        }
    }
}
