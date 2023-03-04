using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(APieceOfWoodIT.Startup))]
namespace APieceOfWoodIT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
