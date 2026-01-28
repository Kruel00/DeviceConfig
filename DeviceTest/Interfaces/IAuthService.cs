namespace DeviceTest;

public interface IAuthService
{
    Task<bool> LoginAsync(string username, string password);
    void Logout();
}
