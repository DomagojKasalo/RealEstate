using application.CRUDservices.cpm;
using application.CRUDservices.crm;
using Autofac;
using domain.Interfaces.ICRUDservices.cpm;
using domain.Interfaces.ICRUDservices.crm;
using xtend_platform_application.CRUDservices.crm;

namespace application
{
    public class AppModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<RealestateCatalogItemServices>().As<IRealestateCatalogItemServices>().InstancePerLifetimeScope();
            builder.RegisterType<RealestateCatalogServices>().As<IRealestateCatalogServices>().InstancePerLifetimeScope();
            builder.RegisterType<RealestateCatalogTypeServices>().As<IRealestateCatalogTypeServices>().InstancePerLifetimeScope();
            builder.RegisterType<RealestateCatalogItemTypeServices>().As<IRealestateCatalogItemTypeServices>().InstancePerLifetimeScope();
            builder.RegisterType<RealestateCatalogItemStatusServices>().As<IRealestateCatalogItemStatusServices>().InstancePerLifetimeScope();

            builder.RegisterType<CompanyServices>().As<ICompanyServices>().InstancePerLifetimeScope();
            builder.RegisterType<CompanyTypeServices>().As<ICompanyTypeServices>().InstancePerLifetimeScope();
            builder.RegisterType<EmailService>().As<IEmailServices>().InstancePerLifetimeScope();

        }
    }
}
