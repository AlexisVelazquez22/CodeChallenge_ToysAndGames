using DB.ViewModels;
using System.Net;
using System.Net.Http.Json;

namespace Test
{
    public class CompanyTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Program> _factory;

        public CompanyTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task Get_ReturnEmptyOrNullResponse()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();

            // Act
            var response = await client.GetAsync("api/company");

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
            _outputHelper.WriteLine(responseContent);

        }

        [Fact]
        public async Task Post_SendData_ReturnContentObjectNotNullOrEmpty()
        {
            // Arrange
            var client = _factory.CreateDefaultClient();
            var content = JsonContent.Create( new CompanyRequest
            {
                Title = "LEGO"
            });

            // Act
            var response = await client.PostAsync("api/company", content);

            // Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
            _outputHelper.WriteLine(responseContent);
        }

    }
}
