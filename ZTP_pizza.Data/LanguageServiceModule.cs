using Autofac;
using ZTP_pizza.Data.Interfaces;
using ZTP_pizza.Data.Services;

namespace ZTP_pizza.Data
{
    public class LanguageServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DataService>().As<IDataService>();
            builder.RegisterType<LanguageBuilder>().As<ILanguageBuilder>();
        }
    }
}