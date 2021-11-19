using Practice.MongoDB.DataAccess;
using System;
using System.Threading.Tasks;

namespace Practice.MongoDB
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var productRepo = new ProductCRUD();
            var customerRepo = new CustomerCRUD();
            var orderRepo = new OrderCRUD();

            var userModels = db.Get();
        }
    }
}
