using MongoDB.Driver;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data
{
    public class DatabaseConnection
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase mongoDatabase;

        public DatabaseConnection()
        {
            mongoClient = new MongoClient("mongodb://localhost:27017");
            mongoDatabase = mongoClient.GetDatabase("pizza");
        }

        public IMongoCollection<Pizza> GetData(string name)
        {
            return mongoDatabase.GetCollection<Pizza>(name);
        }
    }
}
