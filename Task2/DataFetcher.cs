using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Task2.Models;

namespace Task2;
public class DataFetcher
{
    private static readonly HttpClient _httpClient = new HttpClient();
    public async Task<IEnumerable<Post>> GetPosts(string uri)
    {
        return await GetData<Post>(uri);
    }

    public async Task<IEnumerable<User>> GetUsers(string uri)
    {
        return await GetData<User>(uri);
    }

    private async Task<IEnumerable<T>> GetData<T>(string uri)
    {
        try
        {
            var response = await _httpClient.GetAsync(uri);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<List<T>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Request failed: {ex.Message}");
            return [];
        }
    }
}
