using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data.Interfaces
{
    public interface IRepository
    {
        IEnumerable<Pizza> GetPizza(Expression<Func<Pizza, bool>> query);
    }
}
