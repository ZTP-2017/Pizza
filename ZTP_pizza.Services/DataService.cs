using System.Collections.Generic;
using ZTP_pizza.Data;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Services
{
    public interface IDataService
    {
        IEnumerable<Pizza> GetAll();
        void AddPizza(Pizza pizza);
        PizzaContent GetPizzaContentByLang(Pizza pizza, string lang);
    }

    public class DataService : IDataService
    {
        private readonly IRepo dataRepo;
        private readonly ILanguageSelectorsBuilder langSelectorsBuilder;

        public DataService(IRepo dataRepo, ILanguageSelectorsBuilder langSelectorsBuilder)
        {
            this.dataRepo = dataRepo;
            this.langSelectorsBuilder = langSelectorsBuilder;
        }

        public IEnumerable<Pizza> GetAll()
        {
            return dataRepo.GetPizzaByQuery(x => true);
        }

        public void AddPizza(Pizza pizza)
        {
            dataRepo.AddPizza(pizza);
        }

        public PizzaContent GetPizzaContentByLang(Pizza pizza, string lang)
        {
            var langSelector = langSelectorsBuilder.getLanguageSelectorForLanguageCode(lang);

            return langSelector.GetContent(pizza);
        }
    }
}