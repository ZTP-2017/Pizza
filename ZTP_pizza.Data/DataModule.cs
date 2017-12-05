using Autofac;
using ZTP_pizza.Data.Interfaces;

namespace ZTP_pizza.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DatabaseConnection()).As<DatabaseConnection>();
            builder.RegisterType<Repository>().As<IRepository>();
        }
    }
}
