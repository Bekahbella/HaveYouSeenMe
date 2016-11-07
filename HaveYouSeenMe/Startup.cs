using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HaveYouSeenMe.Startup))]
namespace HaveYouSeenMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
