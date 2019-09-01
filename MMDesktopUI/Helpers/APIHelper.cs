using MMDesktopUI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MMDesktopUI.Helpers
{
    public class APIHelper : IAPIHelper
    {
        #region -- Properties --
        private HttpClient apiClient;
        #endregion

        #region -- Constructor --
        public APIHelper()
        {
            InitializaClient();
        }
        #endregion

        #region -- Methodes --
        private void InitializaClient()
        {
            string api = ConfigurationManager.AppSettings["api"];

            apiClient = new HttpClient();
            apiClient.BaseAddress = new Uri(api);
            apiClient.DefaultRequestHeaders.Accept.Clear();
            apiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<AuthenticatedUser> Authenticate(string userName, string password)
        {
            var data = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("userName", userName),
                new KeyValuePair<string, string>("password", password)
            });

            // -- Url --
            /* Dans App.config, On rajoute une section de configuration
             * L'url se trouve dans les proprietes du webAPI 'Web'
             * Biensur il faut avoir defini une methode /token dans le WebAPI avec Swagger
             * */
            //using (HttpRequestMessage response = await apiClient.PostAsync("/Token", data))
            using (var response = await apiClient.PostAsync("/Token", data))
            {
                // -- Ajouter 'ASPNet.WebApi.client' dans Nuguet Package -- 
                if (response.IsSuccessStatusCode)
                {
                    var result = await response.Content.ReadAsAsync<AuthenticatedUser>();
                    return result;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
        #endregion
    }
}
