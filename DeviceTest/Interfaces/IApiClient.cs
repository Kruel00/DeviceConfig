namespace DeviceTest;

public interface IApiClient
{
    Task<T> GetAsync<T>(string uri);
    Task<T> PostAsync<T>(string uri, object body);
}
