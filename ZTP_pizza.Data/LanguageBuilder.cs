using ZTP_pizza.Data.Interfaces;
using ZTP_pizza.Data.Services;

namespace ZTP_pizza.Data
{
    public class LanguageBuilder : ILanguageBuilder
    {
        private readonly ILanguageService _defaultLanguage;

        public LanguageBuilder()
        {
            var anyLanguage = new LanguageService(null);

            var polishLanguage = new LanguageService("pl")
            {
                NextLanguage = anyLanguage
            };

            _defaultLanguage = new LanguageService("en")
            {
                NextLanguage = polishLanguage
            };
        }

        public LanguageService GetLanguageService(string languageCode)
        {
            return new LanguageService(languageCode)
            {
                NextLanguage = _defaultLanguage
            }; 
        }
    }
}
