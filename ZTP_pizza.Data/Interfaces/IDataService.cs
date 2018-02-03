using System.Collections.Generic;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data.Interfaces
{
    public interface IDataService
    {
        IEnumerable<Pizza> GetAllPizza();
        PizzaContent GetPizzaContentByLanguageCode(Pizza pizza, string languageCode);
    }
}
