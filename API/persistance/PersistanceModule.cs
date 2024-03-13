using Autofac;
using domain.Interfaces.Repositories;
using persistance;
using Module = Autofac.Module;

namespace xtend_platform_persistance
{
    public class PersistanceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
        }
    }
}
