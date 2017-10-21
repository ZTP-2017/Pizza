using Autofac;

namespace ZTP_pizza.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new DatabaseConnection()).As<DatabaseConnection>();
            builder.RegisterType<Repo>().As<IRepo>();
        }
    }
}
