using ATA.Check.Web.Implementations;
using Bit.Http.Contracts;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ATA.Check.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public ATACheckAuthenticationStateProvider BlazorDualModeAuthenticationStateProvider { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public async Task Login()
        {
            Token token = await SecurityService.LoginWithCredentials(Username, Password, "BlazorDualModeResOwner", "secret");
            BlazorDualModeAuthenticationStateProvider.StateHasChanged();
        }

        public async Task Logout()
        {
            await TokenProvider.SetTokenAsync(null);
            BlazorDualModeAuthenticationStateProvider.StateHasChanged();
        }
    }
}
