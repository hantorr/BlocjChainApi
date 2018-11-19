using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BlockChainFront.Startup))]
namespace BlockChainFront
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
