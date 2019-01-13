using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(datezite.Startup))]
namespace datezite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
