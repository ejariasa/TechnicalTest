using Models.Common;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiRepository.Api
{
    public class EmployeeRepository
    {
    
        private  const string BaseUrl = "http://masglobaltestapi.azurewebsites.net/";

        #region Public Methods

        public virtual T MakeGetAPICall<T>(string apiUrl)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(BaseUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = client.GetAsync(apiUrl).Result;

                    if (CheckStatusCode(response))
                    {
                        var result = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                        return JsonConvert.DeserializeObject<T>(result);
                    }

                    return default(T);
                }
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
        #endregion
        #region Private Methods
        bool CheckStatusCode(HttpResponseMessage response)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpStatusCodeException((int)response.StatusCode, response.ReasonPhrase);
            }

            return true;
        }
        #endregion
    }
}
