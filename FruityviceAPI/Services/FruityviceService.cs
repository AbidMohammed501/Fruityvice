using Newtonsoft.Json;

namespace FruityviceAPI.Services
{
    public interface IFruityviceService
    {
        Task<IEnumerable<Fruits>> FruitsList();
        Task<IEnumerable<Fruits>> FruitsListByFruitfamily(string family);

    }

    public class FruityviceService : IFruityviceService
    {
        private readonly HttpClient _httpClient;

        public FruityviceService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("url");
        }

        public async Task<IEnumerable<Fruits>> FruitsList()
        {
            try
            {
                var response = await _httpClient.GetAsync("fruit/all");
                response.EnsureSuccessStatusCode();
                var content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<IEnumerable<Fruits>>(content) ?? Enumerable.Empty<Fruits>();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Fruits>> FruitsListByFruitfamily(string family)
        {
            try
            {
                var fruitsList = await FruitsList();
                return fruitsList.Where(x => x.Family == family).ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
