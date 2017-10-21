using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data
{
    public interface IRepo
    {
        Pizza GetPizzaById(ObjectId id);
        IEnumerable<Pizza> GetPizzaByQuery(Expression<Func<Pizza, bool>> predicate);
        void AddPizza(Pizza item);
    }

    public class Repo : IRepo
    {
        private DatabaseConnection con;
        public IMongoCollection<Pizza> Data { get; set; }

        public Repo(DatabaseConnection con)
        {
            this.con = con;
            Data = con.GetData("pizza");
        }

        public Pizza GetPizzaById(ObjectId id)
        {
            return Data.Find(x => x.Id == id).FirstOrDefault();
        }

        public IEnumerable<Pizza> GetPizzaByQuery(Expression<Func<Pizza, bool>> predicate)
        {
            return Data.Find(predicate).ToList();
        }

        public void AddPizza(Pizza item)
        {
            Data.InsertOne(item);
        }
    }
}
