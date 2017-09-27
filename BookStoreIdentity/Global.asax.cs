using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Autofac;
using Autofac.Integration.Mvc;
using Model.DAL;
using Model.Interface;
using Model.Class;

namespace BookStoreIdentity
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            // Fixing claim issue. https://stack247.wordpress.com/2013/02/22/antiforgerytoken-a-claim-of-type-nameidentifier-or-identityprovider-was-not-present-on-provided-claimsidentity/   
            AntiForgeryConfig.UniqueClaimTypeIdentifier = ClaimTypes.Name;

            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<BookStoreIdentityDbContext>().As<IBookStoreIdentityDbContext>();
            builder.RegisterType<AuthorDAO>().As<IAuthorDAO>();
            builder.RegisterType<BookDAO>().As<IBookDAO>();
            builder.RegisterType<LoginDAO>().As<ILoginDAO>();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
