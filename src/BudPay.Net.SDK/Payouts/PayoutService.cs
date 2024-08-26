using BudPay.Net.SDK.DataTransfers;
using BudPay.Net.SDK.Interfaces;

namespace BudPay.Net.SDK.Payouts;

public class PayoutService : IPayoutService
{
    private readonly string _token;
     private readonly HttpClient _httpClient;
     private readonly EncyptionService encyptionService;
    private  IBudPayClientIntegration _hiBudPayClientIntegration;


    private PayoutService(HttpClient httpClient, EncyptionService encyptionService)
    {
        _httpClient = httpClient;
        this.encyptionService = encyptionService;
    }

    public PayoutService(string token) : this(new HttpClient(), new EncyptionService())
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


  public async Task<BankListResponse> BankListAsync(string? currency = "NGN")
  {
    return await HiBudPayClientIntegration.BankList(_token, currency);
  }
 
  public async Task<AccountNumberValidationResponse> AccountNameValidation(string bankCode, string accountNumber, string currency)
  {
    return await HiBudPayClientIntegration.AccountNameValidation(bankCode,accountNumber, currency, _token);
  }


  public async Task<SinglePayoutResponse> SinglePayout(SinglePayoutRequest request)
  {
    return await HiBudPayClientIntegration.SinglePayout(request, _token);
  }


  public async Task<BulkPayoutResponse> BulkPayout(BulkPayoutRequest request)
  {
    return await HiBudPayClientIntegration.BulkPayout(request, _token);
  }

public async Task< VerifyPayoutResponse> VerifyPayout(string reference)
{
    return await HiBudPayClientIntegration.VerifyPayout(reference, _token);
}

public async Task<ListAllPayoutResponse> ListAllPayouts()
{
   return await HiBudPayClientIntegration.ListAllPayouts(_token);
}

public async Task<PayoutFeeResponse> PayoutFee(string currency, string amount)
{
    return await HiBudPayClientIntegration.PayoutFee(currency, amount, _token);
}

public async Task< WalletBalanceResponse> WalletBalance(string currency)
{
  return await HiBudPayClientIntegration.WalletBalance(currency, _token);
}

public async Task<WalletTransactionResponse> WalletTransactions(string currency)
{
    return await HiBudPayClientIntegration.WalletTransactions(currency, _token);
}

}
