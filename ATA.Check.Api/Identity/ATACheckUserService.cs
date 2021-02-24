using Bit.Core.Exceptions;
using Bit.Core.Models;
using Bit.IdentityServer.Implementations;
using IdentityServer3.Core.Models;
using System.Threading;
using System.Threading.Tasks;

namespace ATA.Check.Api.Identity
{
    public class ATACheckUserService : UserService
    {
        public override Task<BitJwtToken> LocalLogin(LocalAuthenticationContext context, CancellationToken cancellationToken)
        {
            if (context.UserName == context.Password)
                return Task.FromResult(new BitJwtToken { UserId = context.UserName });

            throw new DomainLogicException("LoginFailed");
        }
    }
}
