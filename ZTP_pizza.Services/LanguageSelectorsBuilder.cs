using System;
using System.Collections.Generic;
using System.Text;

namespace ZTP_pizza.Services
{
    public interface ILanguageSelectorsBuilder
    {
        LanguageSelector getLanguageSelectorForLanguageCode(string code);
    }

    public class LanguageSelectorsBuilder : ILanguageSelectorsBuilder
    {
        private readonly ILanguageSelector langSelector;

        public LanguageSelectorsBuilder()
        {
            var anyLang = new LanguageSelector(null);
            var plLang = new LanguageSelector("pl");
            var enLang = new LanguageSelector("en");

            enLang.failureSelector = plLang;
            plLang.failureSelector = anyLang;

            langSelector = enLang;
        }

        public LanguageSelector getLanguageSelectorForLanguageCode(string code)
        {
            var languageSelector = new LanguageSelector(code);
            languageSelector.failureSelector = langSelector;

            return languageSelector;
        }
    }
}
