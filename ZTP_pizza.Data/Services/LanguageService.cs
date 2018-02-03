using System.Linq;
using ZTP_pizza.Data.Model;
using ZTP_pizza.Data.Interfaces;

namespace ZTP_pizza.Data.Services
{
    public class LanguageService : ILanguageService
    {
        public ILanguageService NextLanguage;
        private readonly string _languageCode;

        public LanguageService(string languageCode)
        {
            _languageCode = languageCode;
        }

        public PizzaContent GetPizzaContent(Pizza pizza)
        {
            var pizzaContent = pizza.Contents
                .FirstOrDefault(x => x.LanguageCode == _languageCode);

            if (pizzaContent != null)
            {
                return pizzaContent;
            }

            return NextLanguage != null ? 
                NextLanguage.GetPizzaContent(pizza) : 
                pizza.Contents.FirstOrDefault();
        }
    }
}
