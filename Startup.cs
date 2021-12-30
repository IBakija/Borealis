using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Borealis.Startup))]
namespace Borealis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
