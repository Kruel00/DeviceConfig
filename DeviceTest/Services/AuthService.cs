using System.Net.Http;
using System.Net.Http.Json;

namespace DeviceTest;

public static class AuthService
{
    private static string? _token;

    public static  async Task<string> LoginAsync(string username, string password)
    {
     using var client = new HttpClient();

        var response = await client.PostAsJsonAsync(
      "http://localhost:5169/api/Auth/login",
      new LoginRequest
      {
          Email = username,
          Password = password
      });

        if (!response.IsSuccessStatusCode)
            return null;

        var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
        _token = result!.Token;

        return _token;
    }

    public static string? Token => _token;

    public static void Logout()
    {
        _token = null;
    }

}
