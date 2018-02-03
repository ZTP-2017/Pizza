using ZTP_pizza.LanguageService.Interfaces;

namespace ZTP_pizza.LanguageService
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
