using System.Collections.Generic;
using ZTP_pizza.Data.Interfaces;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Data.Services
{
    public class DataService : IDataService
    {
        private readonly IRepository _repository;
        private readonly ILanguageBuilder _languageBuilder;

        public DataService(IRepository repository, ILanguageBuilder languageBuilder)
        {
            _repository = repository;
            _languageBuilder = languageBuilder;
        }

        public IEnumerable<Pizza> GetAllPizza()
        {
            return _repository.GetPizza(x => true);
        }

        public PizzaContent GetPizzaContentByLanguageCode(Pizza pizza, string languageCode)
        {
            var languageService = _languageBuilder
                .GetLanguageService(languageCode);

            return languageService.GetPizzaContent(pizza);
        }
    }
}