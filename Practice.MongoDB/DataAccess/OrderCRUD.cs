using MongoDB.Driver;
using Practice.MongoDB.Models;
using System.Collections.Generic;

namespace Practice.MongoDB.DataAccess
{
    public class OrderCRUD
    {
        MongoClient client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
        IMongoDatabase _database;
        IMongoCollection<OrderModel> _mongoCollection;

        public OrderCRUD()
        {
            _database = client.GetDatabase("Shop");
            _mongoCollection = _database.GetCollection<OrderModel>("Order");
        }

        public void Insert(OrderModel orderModel)
        {
            _mongoCollection.InsertOne(orderModel);
        }

        public IEnumerable<OrderModel> Get()
        {
            return _mongoCollection.Find(Builders<OrderModel>.Filter.Empty).ToList();
        }
    }
}
