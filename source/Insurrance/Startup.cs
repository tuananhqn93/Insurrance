using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Insurrance.Startup))]
namespace Insurrance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
