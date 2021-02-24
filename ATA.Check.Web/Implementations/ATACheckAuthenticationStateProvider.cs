using Bit.Http.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ATA.Check.Web.Implementations
{
    public class ATACheckAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ITokenProvider _tokenProvider;

        public ATACheckAuthenticationStateProvider(ITokenProvider tokenProvider)
        {
            _tokenProvider = tokenProvider;
        }

        public void StateHasChanged()
        {
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        AuthenticationState NoUser() => new AuthenticationState(user: new ClaimsPrincipal());

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            Token token = await _tokenProvider.GetTokenAsync();

            if (token == null)
                return NoUser();

            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(Array.Empty<Claim>(), authenticationType: "Bearer")));
        }
    }
}
