using Autofac;
using ZTP_pizza.LanguageService.Interfaces;

namespace ZTP_pizza.LanguageService
{
    public class LanguageServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataService>().As<IDataService>();
            builder.RegisterType<LanguageSelectorsBuilder>().As<ILanguageSelectorsBuilder>();
        }
    }
}