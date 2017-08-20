using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace API.BusinessLogic
{
    public class UserClaims
    {
        // OWIN auth middleware constants
        public const string scopeElement = "http://schemas.microsoft.com/identity/claims/scope";
        public const string objectIdElement = "http://schemas.microsoft.com/identity/claims/objectidentifier";

        // API Scopes
        public static string ReadPermission = ConfigurationManager.AppSettings["api:ReadScope"];
        public static string WritePermission = ConfigurationManager.AppSettings["api:WriteScope"];

        public static string GetUserId()
        {
            HasRequiredScopes(ReadPermission);
            return ClaimsPrincipal.Current.FindFirst(objectIdElement).Value;
        }

        private static void HasRequiredScopes(string permission)
        {
            if (!ClaimsPrincipal.Current.FindFirst(scopeElement).Value.Contains(permission))
            {
                throw new HttpResponseException(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = $"The Scope claim does not contain the {permission} permission."
                });
            }
        }
    }
}