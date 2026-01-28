namespace DeviceTest;

public class TokenService : ITokenService
{
    public string AccessToken {get; private set;} = string.Empty;

    public void SetToken(string token)
    {
        AccessToken = token;
    }

    public void Clear()
    {
        AccessToken = string.Empty;
    }

}
