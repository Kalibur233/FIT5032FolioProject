using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FIT5032FolioProject.Startup))]
namespace FIT5032FolioProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
