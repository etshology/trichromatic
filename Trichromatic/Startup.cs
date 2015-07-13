using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Trichromatic.Startup))]
namespace Trichromatic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
