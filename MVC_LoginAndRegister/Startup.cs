using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC_LoginAndRegister.Startup))]
namespace MVC_LoginAndRegister
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
