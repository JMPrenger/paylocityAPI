using PaylocityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaylocityConsole
{
    public class HttpService
    {
        protected HttpClient httpClient;

        public HttpService()
        {
            httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:7116");
        }

        public async Task<bool> AddObjects(List<PaylocityDto> objectList)
        {
            var contentString = JsonSerializer.Serialize(objectList);
            var content = new StringContent(contentString, Encoding.UTF8, "application/json");
            var response = await httpClient.PostAsync("/AddObjects", content);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<List<PaylocityDto>> GetObjects()
        {
            var response = await httpClient.GetAsync("/GetAllObjects");
            List<PaylocityDto> objectList;
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                objectList = JsonSerializer.Deserialize<List<PaylocityDto>>(responseString);
            }
            else
            {
                objectList = [];
            }
            return objectList;
        }
    }
}
