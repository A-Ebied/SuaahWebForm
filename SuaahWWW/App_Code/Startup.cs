using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SuaahWWW.Startup))]
namespace SuaahWWW
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
