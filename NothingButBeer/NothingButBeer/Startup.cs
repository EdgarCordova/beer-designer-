using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NothingButBeer.Startup))]
namespace NothingButBeer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
