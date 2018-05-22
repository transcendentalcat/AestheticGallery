using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AestheticGallery.WEB.Startup))]
namespace AestheticGallery.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
