using System.Net.Http;
using System.Threading.Tasks;
using FluentAssertions;
using JsonExtensions.Http;
using Xunit;

namespace JsonExtensions.Tests.Http;

public class HttpExtensionsTests
{
    [Fact]
    public async Task GetJsonAsync_Test()
    {
        // Arrange
        using var httpClient = new HttpClient();

        // Act
        var json = await httpClient.GetJsonAsync("https://jsonplaceholder.typicode.com/todos/1");

        // Assert
        json.GetProperty("userId").GetInt32().Should().Be(1);
        json.GetProperty("id").GetInt32().Should().Be(1);
        json.GetProperty("title").GetString().Should().Be("delectus aut autem");
        json.GetProperty("completed").GetBoolean().Should().BeFalse();
    }
}