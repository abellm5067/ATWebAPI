using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Security.Claims;

public class CustomRolesAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        if ((bool)(context.HttpContext.User?.Identity?.IsAuthenticated))
        {
            var roles = Roles?.Split(",") ?? new string[] { "anony" };
            if (roles.Any() && !roles.Any(role => context.HttpContext.User.IsInRole(role)))
            {
                context.Result = new ForbidResult();
                return;
            }
        }
        else
        {
            context.Result = new UnauthorizedResult();
        }
    }
}