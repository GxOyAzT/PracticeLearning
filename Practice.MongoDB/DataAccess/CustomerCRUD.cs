using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using Practice.MongoDB.Models;

namespace Practice.MongoDB.DataAccess
{
    public class CustomerCRUD
    {
        MongoClient client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
        IMongoDatabase _database;
        IMongoCollection<CustomerModel> _mongoCollection;

        public CustomerCRUD()
        {
            _database = client.GetDatabase("Shop");
            _mongoCollection = _database.GetCollection<CustomerModel>("Customer");
        }

        public void Insert(CustomerModel userModel)
        {
            _mongoCollection.InsertOne(userModel);
        }

        public IEnumerable<CustomerModel> Get()
        {
            return _mongoCollection.Find(Builders<CustomerModel>.Filter.Empty).ToList();
        }

        public async Task<CustomerModel> Get(int id)
        {
            return await _mongoCollection.Find(Builders<CustomerModel>.Filter.Eq("Id", id)).Limit(1).SingleAsync();
        }
    }
}
