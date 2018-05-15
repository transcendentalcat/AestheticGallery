using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AestheticGallery.Startup))]
namespace AestheticGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
