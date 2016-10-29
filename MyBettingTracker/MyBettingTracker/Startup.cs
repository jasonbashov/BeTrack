using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBettingTracker.Startup))]
namespace MyBettingTracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
