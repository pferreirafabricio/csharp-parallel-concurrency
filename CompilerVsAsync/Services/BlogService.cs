using System.Text.Json;
using CompilerVsAsync.Entities;

namespace CompilerVsAsync.Services;

public class BlogService
{
    public async Task<Post?> ObterPostPorIdAsync(int postId)
    {
        var endpoint = $"https://jsonplaceholder.typicode.com/posts/{postId}";

        using var httpClient = new HttpClient();
        using var response = await httpClient.GetAsync(endpoint);
        var json = await response.Content.ReadAsStringAsync();
        var post = JsonSerializer.Deserialize<Post>(json);
        return post;
    }
}