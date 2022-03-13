using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestApplication.Models;
using System.Net.Http;
using System.Text;

namespace TestApplication.Services
{
    public class ManagementApiService : IManagementApiService
    {
        public async Task<List<ManagementModel>> searchManagement(string searchString)
        {
            using (var client = new HttpClient())
            {
                var url = new Uri("https://vebucppy86.execute-api.us-east-1.amazonaws.com/elasticsearch-api-test?q={searchString}");
                var result = new List<ManagementModel>();
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<List<ManagementModel>>(response.Content.ReadAsStringAsync().Result);
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
