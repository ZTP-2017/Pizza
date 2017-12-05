using System.Linq;
using ZTP_pizza.Data.Model;
using ZTP_pizza.Services.Interfaces;

namespace ZTP_pizza.Services
{
    public class LanguageSelector : ILanguageSelector
    {
        public ILanguageSelector NextSelector;
        private readonly string _langCode;

        public LanguageSelector(string langCode)
        {
            _langCode = langCode;
        }

        public PizzaContent GetContent(Pizza pizza)
        {
            var pizzaContent = pizza.Contents.FirstOrDefault(x => x.LanguageCode == _langCode);

            if (pizzaContent != null)
            {
                return pizzaContent;
            }

            return NextSelector != null ? NextSelector.GetContent(pizza) : pizza.Contents.FirstOrDefault();
        }
    }
}
