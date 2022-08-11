using Newtonsoft.Json;
using Services.ViewModels;
using System.Net;
using System.Net.Http.Json;

namespace Test
{
    public class ProductTest
    {
        private readonly ITestOutputHelper _outputHelper;
        private readonly WebApplicationFactory<Program> _factory;

        public ProductTest(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
            _factory = new WebApplicationFactory<Program>();
        }

        [Fact]
        public async Task GetAll_ReturnEmptyOrNullResponse()
        {
            //Arrange
            var client = _factory.CreateDefaultClient();

            //Act
            var response = await client.GetAsync("/api/product");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
        public async Task Post_GetReturnResponse_NotNullContent()
        {
            //Arrange
            var client = _factory.CreateDefaultClient();
            var content = JsonContent.Create( new ProductRequest
            {
                Name = "Name",
                Description = "Description",
                AgeRestriction = 99,
                Price = 999,
                CompanyId = 1
            });

            //Act
            var response = await client.PostAsync("/api/product", content);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
        public async Task Put_GetReturnResponse_WhenExistInTheDB()
        {
            //Arrange
            var client = _factory.CreateDefaultClient();
            var content = JsonContent.Create(new ProductRequest
            {
                Name = "Name",
                Description = "Description",
                AgeRestriction = 99,
                Price = 999,
                CompanyId = 3
            });

            //Act
            var response = await client.PutAsync("/api/product/12", content);

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            var responseContent = response.Content.ReadAsStringAsync().Result;
            Assert.NotNull(responseContent);
            Assert.NotEmpty(responseContent);
            Assert.Contains(content.ReadAsStringAsync().Result.TrimStart('{').TrimEnd('}'), responseContent);
            _outputHelper.WriteLine(JsonConvert.SerializeObject(responseContent));
        }

        [Fact]
        public async Task Delete_WhenExistInTheDB()
        {
            //Arrange
            var client = _factory.CreateDefaultClient();

            //Act
            var response = await client.DeleteAsync("api/product/1072");

            //Assert
            Assert.NotNull(response);
            Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
        }

    }
}