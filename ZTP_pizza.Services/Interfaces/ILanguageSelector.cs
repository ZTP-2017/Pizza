using ZTP_pizza.Data.Model;

namespace ZTP_pizza.LanguageService.Interfaces
{
    public interface ILanguageSelector
    {
        PizzaContent GetContent(Pizza pizza);
    }
}
