using System.Collections.Generic;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Services.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Pizza> GetAll();
        PizzaContent GetPizzaContentByLang(Pizza pizza, string lang);
    }
}
