using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IHiBudPayClientIntegration
{
    Task<StandardCheckoutResponse> StandardCheckout(StandardCheckoutRequest request, string token);
    Task<string> InitializeTransaction(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin, 
    string amount, string callback, string currency, string email, string reference,  byte[] key, byte[] iv, string token);
    Task<BankTransferCheckoutResponse> BankTransferCheckout(BankTransferCheckoutRequest request, string token);
    Task<string> MomoPaymentProviders(string currency, string token);
    Task<string> MomoPaymentRequest(MomoInitiatePaymentRequest request, string token);
    Task<string> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request, string token);
    Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest request, string token);
    Task<VerifyCollectionTransactionResponse> VerifyTransaction(string reference, string token);
    Task<FetchTransactionResponse> FetchTransactionById(string Id, string token);
    Task<FetchAllTransactionsResponse> FetchAllTransactions(string token);
}
