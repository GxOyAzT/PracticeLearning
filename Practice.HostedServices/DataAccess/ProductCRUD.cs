using MongoDB.Driver;
using Practice.HostedServices.Models;
using System.Collections.Generic;

namespace Practice.HostedServices.DataAccess
{
    public class ProductCRUD
    {
        MongoClient client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&appname=MongoDB%20Compass&ssl=false");
        IMongoDatabase _database;
        IMongoCollection<ProductModel> _mongoCollection;

        public ProductCRUD()
        {
            _database = client.GetDatabase("Shop");
            _mongoCollection = _database.GetCollection<ProductModel>("Product");
        }

        public void Insert(ProductModel productModel)
        {
            _mongoCollection.InsertOne(productModel);
        }

        public IEnumerable<ProductModel> Get()
        {
            return _mongoCollection.Find(Builders<ProductModel>.Filter.Empty).ToList();
        }
    }
}
