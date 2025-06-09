using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using NUnit.Framework;

namespace TestingDemo.IntegrationTests
{
    public class TaskBoardTests
    {
        [Test]
        public async Task TestAllBoards()
        {
            // Arrange
            var httpClient = new HttpClient();

            // Act: send a GET request
            var response = await httpClient.GetAsync("https://google.com");

            // Assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));
        }
    }
}