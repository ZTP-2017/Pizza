using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data.Interfaces
{
    public interface ILanguageService
    {
        PizzaContent GetPizzaContent(Pizza pizza);
    }
}
