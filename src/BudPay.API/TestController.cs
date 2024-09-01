using System.Security.Cryptography;
using BudPay.Net.SDK;
using BudPay.Net.SDK.DataTransfers;
using Microsoft.AspNetCore.Mvc;

namespace BudPay.API;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly BudPayApi _budPayApi;

    public TestController(BudPayApi budPayApi)
    {
        _budPayApi = budPayApi;
    }


        [HttpGet("generate-aes-key-iv")]
        public IActionResult GenerateAesKeyAndIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256; // Set the key size to 256 bits (32 bytes)
                aes.GenerateKey();  // Generate a new key
                aes.GenerateIV();   // Generate a new IV (Initialization Vector)

                var keyIvPair = new 
                {
                    Key = Convert.ToBase64String(aes.Key),
                    IV = Convert.ToBase64String(aes.IV)
                };

                return Ok(keyIvPair);
            }
        }


    [HttpPost("standard-checkout")]
    public async Task<IActionResult> StandardCheckout(StandardCheckoutRequest request)
    {
        var response =  await _budPayApi.AcceptPaymentService.StandardCheckoutAsync(request);
        return Ok(response);
    }


  [HttpPost("card-transaction")]
  public async Task<IActionResult> InitiateTransactionV2([FromBody] S2SInitializeTransactionRequest request)
  {

   var response =   await  _budPayApi.AcceptPaymentService.V2InitializeTransactionS2S(request);
   return  Ok(response);
  }


 [HttpPost("bank-transfer-checkout")]
  public async  Task<IActionResult> BankTransferCheckout(BankTransferCheckoutRequest request)
  {
      var response = await _budPayApi.AcceptPaymentService.BankTransferCheckoutAsync(request);
      return Ok(response);
  }


  [HttpGet("momo-providers")]
  public async Task<IActionResult> MomoPaymentProviders(string currency)
  {
    var response = await _budPayApi.AcceptPaymentService.MomoPaymentProvidersAsync(currency);
    return Ok(response);
  }

 [HttpPost("momo-payment-request")]
  public async Task<IActionResult> MomoPaymentRequest(MomoInitiatePaymentRequest request)
  {
     var response = await _budPayApi.AcceptPaymentService.MomoPaymentRequestAsync(request);
     return Ok(response);
  }

 [HttpPost("create-invoice")]
  public async Task<IActionResult> CreateInvoice(CreateInvoiceRequest request)
  {
    var response = await _budPayApi.AcceptPaymentService.CreateInvoiceAsync(request);
    return Ok(response);
  }


  [HttpPost("generate-payment-link")]
  public async Task<IActionResult> GeneratePaymentLink(PaymentLinkRequest request)
  {
    var response = await _budPayApi.AcceptPaymentService.GenreratePaymentLinkAsync(request);
    return Ok(response);
  }

  [HttpGet("verify-transaction")]
  public async Task<IActionResult> VerifyTransaction(string reference)
  {
     var response =  await _budPayApi.AcceptPaymentService.VerifyTransactionAsync(reference);
     return  Ok(response);
  }

  [HttpGet("fetch-transaction-by-id")]
  public async Task<IActionResult> FetchTransactionById(string reference)
  {
      var response =  await _budPayApi.AcceptPaymentService.FetchTransactionByIdAsync(reference);
     return  Ok(response);
  }

 [HttpGet("fetch-all-transactions")]
  public async Task<IActionResult> FetchAllTransactions()
  {
    var response = await _budPayApi.AcceptPaymentService.FetchAllTransactionsAsync();
    return Ok(response);
  }

 [HttpGet("bank-list")]
  public async Task<IActionResult> BankList(string? currency)
  {
    var resposne = await _budPayApi.PayoutService.BankListAsync();
     return Ok(resposne);
  }

  [HttpPost("account-name-validation")]
  public async Task<IActionResult> AccountNameValidation([FromBody] AccountNumberValidationRequest request)
  {
     var response = await _budPayApi.PayoutService.AccountNameValidation(request.bank_code, request.account_number, request.currency);
     return Ok(response);
  }

  [HttpPost("single-payout")]
  public async Task<IActionResult> SinglePayout(SinglePayoutRequest request)
  {
     var response = await _budPayApi.PayoutService.SinglePayout(request);
     return Ok(response);
  }

 [HttpPost("bulk-payout")]
  public async Task<IActionResult> BulkPayout(BulkPayoutRequest request)
  {
    var response = await _budPayApi.PayoutService.BulkPayout(request);
    return Ok(response);    
  }

 [HttpGet("verify-payout")]
  public async Task<IActionResult> VerifyPayout(string reference)
  {
    var response = await _budPayApi.PayoutService.VerifyPayout(reference);
    return Ok(response);
  }

 [HttpGet("list-all-payouts")]
  public async Task<IActionResult> ListAllPayouts()
  {
    var response = await _budPayApi.PayoutService.ListAllPayouts();
    return Ok(response);
  }

  [HttpPost("payout-fee")]
  public async Task<IActionResult> PayoutFee(string currency, string amount)
  {
    var response =  await _budPayApi.PayoutService.PayoutFee(currency, amount);
    return Ok(response);
  }

 [HttpGet("wallet-balance")]
  public async Task<IActionResult> WalletBalance(string currency)
  {
    var response = await _budPayApi.PayoutService.WalletBalance(currency);
    return Ok(response);
  }

[HttpGet("wallet-transaction")]
  public async Task<IActionResult> WalletTransactions(string currency)
  {
    var response = await _budPayApi.PayoutService.WalletTransactions(currency);
    return Ok(response);
  }

 [HttpGet("get-airtime-providers")]
  public async Task<IActionResult> GetAirtimeProviders()
  {
    var response = await _budPayApi.BillPaymentService.GetAirtimeProvidersAsync();
    return Ok(response);
  }

 [HttpPost("get-airtime-top-up")]
  public async Task<IActionResult> AirtimeTopup(AirtimeTopupRequest request)
  {
    var response = await _budPayApi.BillPaymentService.AirtimeTopupAsync(request);
    return Ok(response);
  }

 [HttpGet("get-internet-providers")]
  public async Task<IActionResult> GetInternetProviders()
  {
    var response = await _budPayApi.BillPaymentService.GetInternetProvidersAsync();
    return Ok(response);
  }

  [HttpGet("internet-data-plans")]
  public async Task<IActionResult> InternetDataPlans(string provider)
  {
    var response = await _budPayApi.BillPaymentService.InternetDataPlansAsync(provider);
    return Ok(response);
  }

[HttpPost("internet-data-purchase")]
  public async Task<IActionResult> InternetDataPurchase(InternetDataPurchaseRequest request)
  {
    var response = await _budPayApi.BillPaymentService.InternetDataPurchaseAsync(request);
    return Ok(response);
  }

 [HttpGet("get-all-tv-providers")]
  public async Task<IActionResult> GetAllTvProvidersAsync()
  {
    var response = await _budPayApi.BillPaymentService.GetAllTvProvidersAsync();
    return Ok(response);
  }

 [HttpGet("tv-packages")]
  public async Task<IActionResult> TvPackagesAsync(string provider)
  {
    var response = await _budPayApi.BillPaymentService.TvPackagesAsync(provider);
    return Ok(response);
  }

 [HttpPost("tv-validate")]
  public async Task<IActionResult> TvValidateAsync(string provider, string number)
  {
    var response = await _budPayApi.BillPaymentService.TvValidateAsync(provider, number);
    return Ok(response);
  }

  [HttpPost("tv-subscription")]
  public async Task<IActionResult> TvSubscriptionAsync([FromBody]TvSubscriptionRequest request)
  {
    var response = await _budPayApi.BillPaymentService.TvSubscriptionAsync(request);
    return Ok(response);
  }
  
  [HttpGet("electricity-providers")]
  public async Task<IActionResult> ElectricityProvidersAsync()
  {
     var response = await _budPayApi.BillPaymentService.ElectricityProviders();
     return Ok(response);
  }

  [HttpPost("electricity-validate")]
  public async Task<IActionResult> ElectricityValidateAsync(string provider, string type, string number)
  {
    var response = await _budPayApi.BillPaymentService.ElectricityValidate(provider, type, number);
    return Ok(response);
  }

 [HttpPost("electricity-recharge")]
  public async Task<IActionResult> ElectricityRecharge(ElectricityRechargeRequest rechargeRequest)
  {
    var response = await _budPayApi.BillPaymentService.ElectricityRecharge(rechargeRequest);
    return Ok(response);
  }
}



