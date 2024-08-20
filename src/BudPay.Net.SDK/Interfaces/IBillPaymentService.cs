using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IBillPaymentService
{
    Task<AirtimeProvderResponse> GetAirtimeProvidersAsync();
    Task<AirtimeTopupResponse> AirtimeTopupAsync(AirtimeTopupRequest request);
    Task<InternetProviderResponse> GetInternetProvidersAsync();
     Task<InternetDataPlansResponse> InternetDataPlansAsync(string provider);
     Task<InternetDataPurchaseResponse> InternetDataPurchaseAsync(InternetDataPurchaseRequest request);
     Task<TvProvidersResponse> GetAllTvProvidersAsync();
     Task<TvPackageResponse> TvPackagesAsync(string provider);
     Task<TvValidateResponse> TvValidateAsync(string provider, string number);
     Task<TvSubscriptionResponse> TvSubscriptionAsync(string provider, string number, string code, string reference);
     Task<ElectricityProviderResponse> ElectricityProviders();
     Task<ElectricityValidateResponse> ElectricityValidate(string provider, string type, string number);
     Task<ElectricityRechargeResponse> ElectricityRecharge(ElectricityRechargeRequest request);
}
