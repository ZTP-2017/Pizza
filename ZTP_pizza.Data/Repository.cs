using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZTP_pizza.Data.Interfaces;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data
{
    public class Repository : IRepository
    {
        public IMongoCollection<Pizza> Data { get; set; }

        public Repository(DbContext con)
        {
            Data = con.GetData();
        }

        public IEnumerable<Pizza> GetPizza(Expression<Func<Pizza, bool>> query)
        {
            return Data.Find(query).ToList();
        }
    }
}
