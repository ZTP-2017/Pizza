using System.Collections.Generic;
using ZTP_pizza.Data.Interfaces;
using ZTP_pizza.Data.Model;
using ZTP_pizza.LanguageService.Interfaces;

namespace ZTP_pizza.LanguageService
{
    public class DataService : IDataService
    {
        private readonly IRepository _repository;
        private readonly ILanguageSelectorsBuilder _langSelectorsBuilder;

        public DataService(IRepository dataRepo, ILanguageSelectorsBuilder langSelectorsBuilder)
        {
            _repository = dataRepo;
            _langSelectorsBuilder = langSelectorsBuilder;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return _repository.GetPizza(x => true);
        }

        public PizzaContent GetPizzaContentByLang(Pizza pizza, string lang)
        {
            var langSelector = _langSelectorsBuilder.GetMainSelector(lang);

            return langSelector.GetContent(pizza);
        }
    }
}