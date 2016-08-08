using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Talker.Startup))]
namespace Talker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
