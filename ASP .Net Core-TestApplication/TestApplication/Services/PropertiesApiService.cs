using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using TestApplication.Models;

namespace TestApplication.Services
{
    public class PropertiesApiService : IPropertiesApiService
    {

        public async Task<List<PropertyModel>> searchProperties(string searchQuery)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://vebucppy86.execute-api.us-east-1.amazonaws.com/elasticsearch-api-gateway?q={searchQuery}");
                var result = new List<PropertyModel>();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<PropertyModel>>(response.Content.ReadAsStringAsync().Result);
                }
                else
                {
                    throw new HttpRequestException(response.ReasonPhrase);
                }

                return result;
            }
        }
    }
}
