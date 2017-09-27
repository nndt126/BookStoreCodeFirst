using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookStoreIdentity.Startup))]
namespace BookStoreIdentity
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
