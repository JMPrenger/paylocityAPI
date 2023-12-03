using PaylocityModels;
using System.Text;
using System.Text.Json;

namespace PaylocityConsole
{
    public class HttpService
    {
        protected HttpClient httpClient;

        public HttpService()
        {
            httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7116")
            };
        }

        public async Task<bool> AddObjects(List<PaylocityDto> objectList)
        {
            var contentString = JsonSerializer.Serialize(objectList);
            var response = await httpClient.PostAsync("/AddObjects", new StringContent(contentString, Encoding.UTF8, "application/json"));

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
            List<PaylocityDto> objectList = [];
            if (response.IsSuccessStatusCode)
            {
                var responseString = await response.Content.ReadAsStringAsync();
                objectList = JsonSerializer.Deserialize<List<PaylocityDto>>(responseString);
            }
            return objectList;
        }
    }
}
