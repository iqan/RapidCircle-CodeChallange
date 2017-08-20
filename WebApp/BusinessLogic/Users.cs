using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace WebApp.BusinessLogic
{
    public class Users
    {
        public static async Task<string> GetAccessToken(HttpContextBase httpContext)
        {
            var accessToken = string.Empty;

            try
            {
                var scope = new string[] { Startup.ReadTasksScope };
                string signedInUserID = ClaimsPrincipal.Current.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier).Value;
                TokenCache userTokenCache = new MSALSessionCache(signedInUserID, httpContext).GetMsalCacheInstance();
                ConfidentialClientApplication cca = new ConfidentialClientApplication(Startup.ClientId, Startup.Authority, Startup.RedirectUri, new ClientCredential(Startup.ClientSecret), userTokenCache, null);

                var user = cca.Users.FirstOrDefault();
                if (user == null)
                {
                    throw new Exception("The User is NULL.  Please clear your cookies and try again.  Specifically delete cookies for 'login.microsoftonline.com'.  See this GitHub issue for more details: https://github.com/Azure-Samples/active-directory-b2c-dotnet-webapp-and-webapi/issues/9");
                }

                AuthenticationResult result = await cca.AcquireTokenSilentAsync(scope, user, Startup.Authority, false);

                accessToken = result.AccessToken;
            }
            catch (System.Exception ex)
            {

                throw;
            }

            return accessToken;
        }
    }
}