using System.Net;
using System.Net.Http.Headers;
using System.Text;
using BudPay.Net.SDK.Constants;
using BudPay.Net.SDK.DataTransfers;
using BudPay.Net.SDK.Interfaces.IIntegrations;
using BudPay.Net.SDK.Services;
using Newtonsoft.Json;

namespace BudPay.Net.SDK;

public class HiBudPayClientIntegration  : IHiBudPayClientIntegration
{
         private readonly HttpClient _client;
         private readonly EncyptionService  _encyptionService;
    public HiBudPayClientIntegration(HttpClient httpClient, EncyptionService encyptionService)
    {
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        _client = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        _client.DefaultRequestHeaders.Add("User-Agent", "Custom User Agent");
        _client.Timeout = TimeSpan.FromMinutes(30);
        _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        ServicePointManager.Expect100Continue = true;
        ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
        _encyptionService = encyptionService;
    }


    public async Task<T> GetAsync<T>(string relativePath, Dictionary<string, string>? content = null, string? token = null)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, relativePath));
            var request = new HttpRequestMessage() { RequestUri = requestUrl, Method = HttpMethod.Get };

             if (token is not null) request.Headers.Add("Authorization", $"Bearer {token}");

            if (content != null) request.Content = new FormUrlEncodedContent(content);

            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private Uri CreateRequestUri(string relativePath, string queryString = "")
        {
            var endpoint = new Uri(string.Concat(BaseConstant.BudpayBaseUrl, relativePath));
            var uriBuilder = new UriBuilder(endpoint);
            if (!string.IsNullOrEmpty(queryString))
            {
                uriBuilder.Query = queryString;
            }
            return uriBuilder.Uri;
        }

        /// <summary>
        /// Common method for making POST calls
        /// </summary>
        public async Task<T> PostAsync<T>(string relativePath, object content, string? token = null, string? encryption = null)
        {
            Uri requestUrl = CreateRequestUri(string.Format(System.Globalization.CultureInfo.InvariantCulture, relativePath));
            var request = new HttpRequestMessage() { RequestUri = requestUrl, Method = HttpMethod.Post, Content = CreateHttpContent(content) };

            if (token is not null) request.Headers.Add("Authorization", $"Bearer {token}");
            if(encryption is not null) request.Headers.Add("Encryption", encryption);

            var response = await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);

            var data = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<T>(data);
        }


        private HttpContent CreateHttpContent(object content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }

        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

    #region  Accept Payment
        public async Task<StandardCheckoutResponse> StandardCheckout(StandardCheckoutRequest request, string token)
        {
           var response = await PostAsync<StandardCheckoutResponse>(BaseConstant.StandardCheckout, request, token);
           if(response is null) return new StandardCheckoutResponse();
            return response;       
        }


        //The Transactions API allows you create and manage payments on your integration.
        //This Server 2 Server Version 1 is for NGN transaction only. To use other currencies, kindly use Version 2


        #region  Server to Server

        public async Task<string> CardEncryption(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin, string reference,  byte[] key, byte[] iv)
        {
            var cardData = new CardDetailsRequest
            {
                data = new CardDetails
                {
                    number = cardNumber,
                    expiryMonth = expiryMonth,
                    expiryYear = expiryYear,
                    cvv = cvv,
                    pin = pin,
                },
                reference = reference,
            };

          string encryptedCard =  _encyptionService.EncryptCard(cardData, key, iv);
          return encryptedCard;   
        }



       // For Mastercard and Visa card transaction, you will get the next step response (3DS2), 
       //while Verve card transaction will take you to the final response (Payment Successful).


        // You are required to open the 3DS2 Response data html in a hidden page to run in background for 20 seconds 
        //and then hit the _links endpoint in the response to proceed.
        // After that you will get the Final Response.
        //Note: You will receive 3DS2 response for cards that support 3DS2. 
        //If not, you will get the Final Response instead.

        public async Task<string> InitializeTransaction(S2SInitializeTransactionRequest request, string token)
        {
             var response = await PostAsync<string>(BaseConstant.InitializeTransactionS2S, request, token);
             if (response is null) return string.Empty;
             return response;   
        }

       
        public async Task<BankTransferCheckoutResponse> BankTransferCheckout(BankTransferCheckoutRequest request, string token)
        {
            var response = await PostAsync<BankTransferCheckoutResponse>(BaseConstant.BankTransferCheckout, request, token);
            if(response is null) return new BankTransferCheckoutResponse();
            return response;
        }


       #region  Server to Server Momo Collection

       /// <summary>
       /// The mobile money payment request API allows you to accept momo payment 
       /// from your customer directly from your application or custom checkout.
       /// </summary>

        public async Task<string> MomoPaymentProviders(string currency, string token)
        {
           var response = await GetAsync<string>(string.Concat(BaseConstant.MomoPaymentProviders, currency), null, token);
           if (response is null) return string.Empty;
           return response;

        }

        public async Task<string> MomoPaymentRequest(MomoInitiatePaymentRequest request, string token)
        {
            var response = await PostAsync<string>(BaseConstant.MonoPaymentRequest, request,  token);
            if(response is null) return string.Empty;
            return response;
        }

        #endregion Server to Server Momo Collection


        public async Task<string> V2InitializeTransactionS2S(S2SInitializeTransactionRequest request, string token)
        {
            var payload = new List<KeyValuePair<string, string>>
            {
                new("amount", request.amount),
                new("card", request.card),
                new("currency", request.currency),
                new("email", request.email),
                new("reference", request.reference)
            };
           
          var stringyfiedPayload =  JsonConvert.SerializeObject(payload);
          var signature = _encyptionService.GenerateHmacSha512Signature(token, stringyfiedPayload);
          var response =  await PostAsync<string>(BaseConstant.InitializeTransactionS2S, request, token, signature);
          if(response is null) return string.Empty;
          return response;
        }
   
    #endregion Server to Server


     public async Task<CreateInvoiceResponse> CreateInvoice(CreateInvoiceRequest request, string token)
     {
        var response = await PostAsync<CreateInvoiceResponse>(BaseConstant.CreateInvoice, request,  token);
        if(response is null) return new CreateInvoiceResponse();
        return response;
     }

     public async Task<PaymentLinkResponse> GeneratePaymentLink(PaymentLinkRequest request, string token)
     {
        var response = await PostAsync<PaymentLinkResponse>(BaseConstant.GeneratePaymentLink, request, token);
        if(response is null) return new PaymentLinkResponse();
        return response;

     }


    public async Task<VerifyCollectionTransactionResponse> VerifyTransaction(string reference, string token)
    {
        var response = await GetAsync<VerifyCollectionTransactionResponse>(string.Concat(BaseConstant.VerifyTransaction, reference), null, token);
        if (response is null) return new VerifyCollectionTransactionResponse();
        return response;
    }


    public async Task<FetchTransactionResponse> FetchTransactionById(string Id, string token)
    {
        var response = await GetAsync<FetchTransactionResponse>(string.Concat(BaseConstant.FetchTransaction, Id), null, token);
          if (response is null) return new FetchTransactionResponse();
        return response;
    }

    public async Task<FetchAllTransactionsResponse> FetchAllTransactions(string token)
    {
        var response = await GetAsync<FetchAllTransactionsResponse>(BaseConstant.FetchAllTransactions, null, token);
        if (response is null) return new FetchAllTransactionsResponse();
        return response;

    }

  #endregion  

}
