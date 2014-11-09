using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamTaskboard.Web.Startup))]
namespace TeamTaskboard.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
