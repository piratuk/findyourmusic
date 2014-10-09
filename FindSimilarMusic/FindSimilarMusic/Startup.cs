using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FindSimilarMusic.Startup))]
namespace FindSimilarMusic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
