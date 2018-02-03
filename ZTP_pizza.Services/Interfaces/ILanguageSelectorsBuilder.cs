namespace ZTP_pizza.LanguageService.Interfaces
{
    public interface ILanguageSelectorsBuilder
    {
        LanguageSelector GetMainSelector(string code);
    }
}
