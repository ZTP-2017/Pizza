using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZTP_pizza.Data.Model;

namespace ZTP_pizza.Services
{
    public interface ILanguageSelector
    {
        PizzaContent GetContent(Pizza pizza);
    }

    public class LanguageSelector : ILanguageSelector
    {
        public ILanguageSelector failureSelector;
        private readonly string langCode;

        public LanguageSelector(string langCode)
        {
            this.langCode = langCode;
        }

        public PizzaContent GetContent(Pizza pizza)
        {
            var pizzaContent = pizza.Contents.Where(x => x.LanguageCode == langCode).FirstOrDefault();

            if (pizzaContent != null)
            {
                return pizzaContent;
            }
            else if (failureSelector != null)
            {
                return failureSelector.GetContent(pizza);
            }
            else
            {
                return pizza.Contents.FirstOrDefault();
            }
        }

    }
}
