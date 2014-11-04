using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TeamTaskboard.App.Startup))]
namespace TeamTaskboard.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
