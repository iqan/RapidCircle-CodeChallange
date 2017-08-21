using Microsoft.Identity.Client;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using WebApp.Services;

namespace WebApp.BusinessLogic
{
    public class Users
    {
        public static async Task<string> GetAccessToken(HttpContextBase httpContext)
        {
            var accessToken = string.Empty;
            accessToken = await GetAccessToken(httpContext, accessToken);
            return accessToken;
        }

        private static async Task<string> GetAccessToken(HttpContextBase httpContext, string accessToken)
        {
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

        internal static void AddUserIfNotExist(string userId, string name, string accessToken)
        {
            try
            {
                var user = new Models.Users();
                user.UserId = userId;
                user.Name = name;

                UsersApi.Adduser(user, accessToken);
                
            }
            catch (System.Exception ex)
            {
            }
        }
    }
}