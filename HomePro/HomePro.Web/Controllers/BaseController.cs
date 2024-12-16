using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace HomePro.Web.Controllers
{
    public class BaseController : Controller
    {        
        protected bool IsGuidValid(string? id, ref Guid parsedGuid)
        {
            // Non-existing parameter in the URL
            if (string.IsNullOrWhiteSpace(id))
            {
                return false;
            }

            // Invalid parameter in the URL
            return Guid.TryParse(id, out parsedGuid);
        }

        /*protected static string? GetUserId(this ClaimsPrincipal? userClaimsPrincipal)
        {
            return userClaimsPrincipal?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? null;
        }*/
    }
}
