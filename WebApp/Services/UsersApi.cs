using Models;
using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.Services
{
    public class UsersApi
    {
        static string endpoint = ConfigurationManager.AppSettings["TaskServiceUrl"];
        static string usersEndpoint = "/api/users";

        public static void Adduser(Users user, string accessToken)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(endpoint);

                    client.DefaultRequestHeaders.Clear();

                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                    var jsonModel = JsonConvert.SerializeObject(user);
                    var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                    // hack to bypass SSL error
                    ServicePointManager.ServerCertificateValidationCallback += (sender, certificate, chain, sslPolicyErrors) => true;

                    var result = client.PostAsync(usersEndpoint, content).Result;
                    
                }
            }
            catch (Exception ex)
            {
                // TODO log it
            }
            
        }
    }
}