using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MidLabTaskCRUD.Startup))]
namespace MidLabTaskCRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
