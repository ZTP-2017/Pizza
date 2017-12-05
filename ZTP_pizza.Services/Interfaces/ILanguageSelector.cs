using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Services.Interfaces
{
    public interface ILanguageSelector
    {
        PizzaContent GetContent(Pizza pizza);
    }
}
