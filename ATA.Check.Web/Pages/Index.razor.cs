using ATA.Check.Web.Implementations;
using Bit.Http.Contracts;
using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace ATA.Check.Web.Pages
{
    public partial class Index
    {
        [Inject]
        public ATACheckAuthenticationStateProvider AtaAuthenticationStateProvider { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public async Task Login()
        {
            Token token = await SecurityService.LoginWithCredentials(Username, Password, "ATACheckResOwner", "secret");
            AtaAuthenticationStateProvider.StateHasChanged();
        }

        public async Task Logout()
        {
            await TokenProvider.SetTokenAsync(null);
            AtaAuthenticationStateProvider.StateHasChanged();
        }
    }
}
