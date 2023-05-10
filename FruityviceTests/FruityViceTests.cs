using FruityviceAPI.Services;
using Microsoft.Extensions.Logging;
using System.Net.Http;


namespace FruityviceTests
{
    public class FruityViceTests
    {
        public class HttpClientFactoryStub : IHttpClientFactory
        {
            public HttpClient CreateClient(string name)
            {
                var httpClient = new HttpClient
                {
                    BaseAddress = new Uri("https://www.fruityvice.com/api/")
                };
                return httpClient;
            }
        }

        [Fact]
        public async Task GetAllFruitsAsync_ReturnsListOfFruits()
        {
            // Arrange
            var httpClientFactory = new HttpClientFactoryStub();
            var fruitService = new FruityviceService(httpClientFactory);

            // Act
            var fruits = await fruitService.FruitsList();

            // Assert
            Assert.NotNull(fruits);
            Assert.NotEmpty(fruits);
        }

        [Theory]
        [InlineData("Rosaceae")]
        public async Task GetFruitsByFamilyAsync_ReturnsListOfFruitsForFamily(string family)
        {
            // Arrange
            var httpClientFactory = new HttpClientFactoryStub();
            var fruitService = new FruityviceService(httpClientFactory);

            // Act
            var fruits = await fruitService.FruitsListByFruitfamily(family);

            // Assert
            Assert.NotNull(fruits);
            Assert.NotEmpty(fruits);
            Assert.All(fruits, f => Assert.Equal(family, f.Family, ignoreCase: true));
        }
    }
}