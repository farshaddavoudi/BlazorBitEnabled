using Bit.Core.Contracts;
using Bit.Core.Exceptions;
using Bit.Core.Implementations;
using Bit.Core.Models;
using Bit.IdentityServer.Implementations;
using IdentityServer3.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ATA.Check.Api.Identity
{
    public class ATACheckUserService : UserService
    {
        public IContentFormatter ContentFormatter { get; set; }

        public override Task<BitJwtToken> LocalLogin(LocalAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context.UserName == context.Password)
            {
                return Task.FromResult(new BitJwtToken
                {
                    UserId = context.UserName,
                    CustomProps = new Dictionary<string, string?>
                    {
                        { "Roles", ContentFormatter.Serialize(context.UserName == "admin" ? new [] { "Staff", "Seller" } : Array.Empty<string>()) }
                    }
                });
            }

            throw new DomainLogicException("LoginFailed");
        }
    }
}
