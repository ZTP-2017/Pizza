using ZTP_pizza.Services.Interfaces;

namespace ZTP_pizza.Services
{
    public class LanguageSelectorsBuilder : ILanguageSelectorsBuilder
    {
        private readonly ILanguageSelector _enLang;

        public LanguageSelectorsBuilder()
        {
            var anyLang = new LanguageSelector(null);

            var plLang = new LanguageSelector("pl")
            {
                NextSelector = anyLang
            };

            _enLang = new LanguageSelector("en")
            {
                NextSelector = plLang
            };
        }

        public LanguageSelector GetMainSelector(string lang)
        {
            return new LanguageSelector(lang)
            {
                NextSelector = _enLang
            }; 
        }
    }
}
