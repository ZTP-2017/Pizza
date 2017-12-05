using Autofac;
using ZTP_pizza.Services.Interfaces;

namespace ZTP_pizza.Services
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataService>().As<IDataService>();
            builder.RegisterType<LanguageSelectorsBuilder>().As<ILanguageSelectorsBuilder>();
        }
    }
}