using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTicket.Startup))]
namespace MyTicket
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
