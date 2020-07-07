using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCForm.Startup))]
namespace MVCForm
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
