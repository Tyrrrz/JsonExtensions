using System.Net.Http;
using System.Threading.Tasks;
using AwesomeAssertions;
using Xunit;

namespace JsonExtensions.Tests;

public class HttpClientExtensionsTests
{
    [Fact]
    public async Task GetJsonAsync_Test()
    {
        // Arrange
        using var http = new HttpClient();

        // Act
        var json = await http.GetJsonAsync("https://jsonplaceholder.typicode.com/todos/1");

        // Assert
        json.GetProperty("userId").GetInt32().Should().Be(1);
        json.GetProperty("id").GetInt32().Should().Be(1);
        json.GetProperty("title").GetString().Should().Be("delectus aut autem");
        json.GetProperty("completed").GetBoolean().Should().BeFalse();
    }
}
