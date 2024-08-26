using BudPay.Net.SDK.DataTransfers;
using BudPay.Net.SDK.Interfaces;

namespace BudPay.Net.SDK.BillPayments;

public class BillPaymentService : IBillPaymentService
{
      private readonly string _token;
     private readonly HttpClient _httpClient;
     private readonly EncyptionService encyptionService;
    private IBudPayClientIntegration _hiBudPayClientIntegration;

   
    private BillPaymentService(HttpClient httpClient, EncyptionService encyptionService)
    {
        _httpClient = httpClient;
        this.encyptionService = encyptionService;
    }

     public BillPaymentService(string token) : this(new HttpClient(), new EncyptionService())
    {
        _token = token;
    }


  private IBudPayClientIntegration HiBudPayClientIntegration
  {
    get
    {
         if(_hiBudPayClientIntegration == null)
         _hiBudPayClientIntegration = new BudPayClientIntegration(_httpClient, encyptionService);
         return _hiBudPayClientIntegration;
    }
  }

  public async Task<AirtimeProvderResponse> GetAirtimeProvidersAsync()
  {
    return  await HiBudPayClientIntegration.GetAirtimeProviders(_token);
  }

  public async Task<AirtimeTopupResponse> AirtimeTopupAsync(AirtimeTopupRequest request)
  {
    return await HiBudPayClientIntegration.AirtimeTopup(request, _token);
  }

  public async Task<InternetProviderResponse> GetInternetProvidersAsync()
  {
    return await HiBudPayClientIntegration.GetInternetProviders(_token);
  }

  public async  Task<InternetDataPlansResponse> InternetDataPlansAsync(string provider)
  {
    return await HiBudPayClientIntegration.InternetDataPlans(provider, _token);
  }

  public async Task<InternetDataPurchaseResponse> InternetDataPurchaseAsync(InternetDataPurchaseRequest request)
  {
    return await HiBudPayClientIntegration.InternetDataPurchase(request, _token);
  }

  public async Task<TvProvidersResponse> GetAllTvProvidersAsync()
  {
    return await HiBudPayClientIntegration.GetAllTvProviders(_token);
  }

  public async Task<TvPackageResponse> TvPackagesAsync(string provider)
  {
    return await HiBudPayClientIntegration.TvPackages(provider, _token);
  }

  public async Task<TvValidateResponse> TvValidateAsync(string provider, string number)
  {
    return await HiBudPayClientIntegration.TvValidate(provider, number, _token);
  } 
  public async Task<TvSubscriptionResponse> TvSubscriptionAsync(string provider, string number, string code, string reference)
  {
    return await HiBudPayClientIntegration.TvSubscription(provider, number, code, reference, _token);
  }

  public async Task<ElectricityProviderResponse> ElectricityProviders()
  {
    return await HiBudPayClientIntegration.ElectricityProviders(_token);
  }

  public async Task<ElectricityValidateResponse> ElectricityValidate(string provider, string type, string number)
  {
    return await HiBudPayClientIntegration.ElectricityValidate(provider, type, number, _token);
  }

  public async Task<ElectricityRechargeResponse> ElectricityRecharge(ElectricityRechargeRequest request)
  {
    return await HiBudPayClientIntegration.ElectricityRecharge(request, _token);
  }
}
