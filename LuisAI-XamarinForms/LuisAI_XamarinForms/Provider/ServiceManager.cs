using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LuisAI_XamarinForms.Provider
{
    class ServiceManager
    {
        private const string LuisUrl = "http://192.168.1.12/LuisBot/api/messages/";

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }

        public async Task<string> PostBot(object data)
        {
            HttpClient client = await GetClient();
            try
            {
                var response = await client.PostAsync(LuisUrl,
                    new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json"));
                if (!response.IsSuccessStatusCode)
                    throw new Exception();

                string content = await response.Content.ReadAsStringAsync();
                return content;
            }
            catch (Exception ex)
            {
                return "Christ no! I ran into an error. Please try again by refreshing the page 😌";
            }
        }
    }
}