using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AzureTableStorageWithMvc.Startup))]
namespace AzureTableStorageWithMvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
