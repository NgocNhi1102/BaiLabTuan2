using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Lab2_Lab3.Startup))]
namespace Lab2_Lab3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
