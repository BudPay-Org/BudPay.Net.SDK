using BudPay.Net.SDK.DataTransfers;
using BudPay.Net.SDK.Interfaces;

namespace BudPay.Net.SDK.Transactions;

public class AcceptPaymentService : IAcceptPaymentService
{
    private readonly string _token;
    private IBudPayClientIntegration _budPayClientIntegration;
    private readonly HttpClient _httpClient;
    private readonly EncyptionService encyptionService;


    public AcceptPaymentService(HttpClient httpClient, EncyptionService encyptionService)
    {
        _httpClient = httpClient;
        this.encyptionService = encyptionService;
    }
    public AcceptPaymentService(string token)
    {
        _token = token;
    }


    private IBudPayClientIntegration HiBudPayClientIntegration
    {
        get
        {
            if (_budPayClientIntegration == null)
                _budPayClientIntegration = new BudPayClientIntegration(_httpClient, encyptionService);
            return _budPayClientIntegration;
        }
    }


    public async Task<StandardCheckoutResponse> StandardCheckoutAsync(StandardCheckoutRequest request)
    {
        return await HiBudPayClientIntegration.StandardCheckout(request, _token);
    }

    public async Task<string> InitializeTransactionAsync(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin,
      string amount, string callback, string currency, string email, string reference, byte[] key, byte[] iv)
    {
        return await HiBudPayClientIntegration.InitializeTransaction(cardNumber, expiryMonth, expiryYear, cvv, pin, amount, callback, currency, email, reference, key, iv, _token);
    }

    public async Task<BankTransferCheckoutResponse> BankTransferCheckoutAsync(BankTransferCheckoutRequest request)
    {
        return await HiBudPayClientIntegration.BankTransferCheckout(request, _token);
    }

    public async Task<string> MomoPaymentProvidersAsync(string currency)
    {
        return await HiBudPayClientIntegration.MomoPaymentProviders(currency, _token);
    }


    public async Task<string> MomoPaymentRequestAsync(MomoInitiatePaymentRequest request)
    {
        return await HiBudPayClientIntegration.MomoPaymentRequest(request, _token);
    }

    public async Task<string> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request)
    {
        return await HiBudPayClientIntegration.V2InitializeTransactionS2S(request, _token);
    }

    public async Task<CreateInvoiceResponse> CreateInvoiceAsync(CreateInvoiceRequest request)
    {
        return await HiBudPayClientIntegration.CreateInvoice(request, _token);
    }

    public async Task<VerifyCollectionTransactionResponse> VerifyTransactionAsync(string reference)
    {
        return await HiBudPayClientIntegration.VerifyTransaction(reference, _token);
    }

    public async Task<FetchTransactionResponse> FetchTransactionByIdAsync(string Id)
    {
        return await HiBudPayClientIntegration.FetchTransactionById(Id, _token);
    }

    public async Task<FetchAllTransactionsResponse> FetchAllTransactionsAsync()
    {
        return await HiBudPayClientIntegration.FetchAllTransactions(_token);
    }

}
