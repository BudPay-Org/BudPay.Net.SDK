namespace BudPay.Net.SDK.Interfaces.IIntegrations;

public interface IHiBudPayClientIntegration
{
    Task<T> GetAsync<T>(string relativePath, Dictionary<string, string>? content = null);
    Task<T> PostAsync<T>(string relativePath, object content, string? token = null);
}
