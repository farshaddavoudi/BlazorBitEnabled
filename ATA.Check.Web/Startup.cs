using ATA.Check.Web.Implementations;
using Bit.Http.Contracts;
using Bit.Http.Implementations;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace ATA.Check.Web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthorizationCore();

            services.AddScoped<ISecurityService, DefaultSecurityService>();
            services.AddTransient<ITokenProvider, DefaultTokenProvider>();

            services.AddScoped<AuthenticationStateProvider, ATACheckAuthenticationStateProvider>();
            services.AddTransient(serviceProvider => (ATACheckAuthenticationStateProvider)serviceProvider.GetRequiredService<AuthenticationStateProvider>());
        }
    }
}