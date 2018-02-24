using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(JapaneseBook.WebApi.Startup))]

namespace JapaneseBook.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}