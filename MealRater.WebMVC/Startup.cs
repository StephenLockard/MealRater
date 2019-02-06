using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MealRater.WebMVC.Startup))]
namespace MealRater.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
