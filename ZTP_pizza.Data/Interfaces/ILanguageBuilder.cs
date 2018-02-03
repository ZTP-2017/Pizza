using ZTP_pizza.Data.Services;

namespace ZTP_pizza.Data.Interfaces
{
    public interface ILanguageBuilder
    {
        LanguageService GetLanguageService(string languageCode);
    }
}
