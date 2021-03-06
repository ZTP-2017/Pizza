﻿using MongoDB.Driver;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data
{
    public class DbContext
    {
        private readonly IMongoDatabase _database;

        public DbContext()
        {
            var client = new MongoClient("mongodb://localhost:27017");
            _database = client.GetDatabase("pizza");
        }

        public IMongoCollection<Pizza> GetData()
        {
            return _database.GetCollection<Pizza>("pizza");
        }
    }
}
