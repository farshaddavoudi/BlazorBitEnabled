using Bit.Core.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using System;
using System.Linq;
using System.Linq.Dynamic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace ATA.Check.Api.Controllers.Filters
{
    public class AtaAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        public string[] Roles { get; set; } = Array.Empty<string>();

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var userInformationProvider = context.HttpContext.RequestServices.GetRequiredService<IUserInformationProvider>();
            var contentFormatter = context.HttpContext.RequestServices.GetRequiredService<IContentFormatter>();
            if (!userInformationProvider.IsAuthenticated())
            {
                context.Result = new ForbidResult();
                return;
            }

            var roles = contentFormatter.Deserialize<string[]>(userInformationProvider.GetBitJwtToken().CustomProps["Roles"]);

            if (!roles.OrderBy(r => r).SequenceEqual(Roles.OrderBy(r => r)))
                context.Result = new ForbidResult();
        }

        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
            var resolver = actionContext.Request.GetOwinContext()
                .GetDependencyResolver();

            var userInformationProvider = resolver
                .Resolve<IUserInformationProvider>();

            var contentFormatter = resolver.Resolve<IContentFormatter>();

            if (!base.IsAuthorized(actionContext))
                return false;

            var roles = contentFormatter.Deserialize<string[]>(userInformationProvider.GetBitJwtToken().CustomProps["Roles"]);

            return roles.OrderBy(r => r).SequenceEqual(Roles.OrderBy(r => r));
        }
    }
}
