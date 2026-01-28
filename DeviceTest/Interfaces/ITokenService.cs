namespace DeviceTest;

public interface ITokenService
{
    string AccessToken { get; }
    void SetToken(string token);
    void Clear();
}
