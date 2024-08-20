using System.Net;
using System.Net.Http.Headers;
using System.Text;
using BudPay.Net.SDK.Constants;
using BudPay.Net.SDK.DataTransfers;
using BudPay.Net.SDK.Interfaces;
using Newtonsoft.Json;

namespace BudPay.Net.SDK;

public class BudPayClientIntegration  : IBudPayClientIntegration
{
         private readonly HttpClient _client;
         private readonly EncyptionService  _encyptionService;
    public BudPayClientIntegration(HttpClient httpClient, EncyptionService encyptionService)
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

        private async Task<string> CardEncryption(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin, string reference,  byte[] key, byte[] iv)
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

        public async Task<string> InitializeTransaction(string cardNumber, string expiryMonth, string expiryYear, string cvv, string pin, string amount, string callback, string currency, string email, string reference,  byte[] key, byte[] iv, string token)
        {
            
             string card = await CardEncryption(cardNumber, expiryMonth, expiryYear, cvv, pin, reference, key, iv);

              var paylod = new List<KeyValuePair<string, string>>
              {
                  new("amount", amount),
                  new("card", card),
                  new("callback", callback),
                  new("currency", currency),
                  new("email", email),
                  new("pin", pin),
                  new("reference", reference),
              };

             var response = await PostAsync<string>(BaseConstant.InitializeTransactionS2S, paylod, token);
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


  #region  Payouts

    public async Task<BankListResponse> BankList(string token, string? currency = "NGN")
    {
        var response = await GetAsync<BankListResponse>(string.Concat(BaseConstant.GetBanks, $"/{currency}"));
        if(response is null) return new BankListResponse();
        return response;
    }

    public async Task<AccountNumberValidationResponse> AccountNameValidation(string bankCode, string accountNumber, string currency, string token)
    {
        var payload = new List<KeyValuePair<string, string>>
        {
            new("bank_code", bankCode),
            new("account_number", accountNumber),
            new("currency", currency)
        };
              
        var response = await PostAsync<AccountNumberValidationResponse>(BaseConstant.AccountNameValidation,  payload, token);
        if (response is null) return new AccountNumberValidationResponse();
        return response;
    }

    public async Task<SinglePayoutResponse> SinglePayout(SinglePayoutRequest request, string token)
    {
       var encryption =   _encyptionService.GenerateHmacSha512Signature(token, JsonConvert.SerializeObject(request));
        var response = await PostAsync<SinglePayoutResponse>(BaseConstant.SinglePayout, request, token, encryption);
        if (response is null) return new SinglePayoutResponse();
        return response;
    }

    public async Task<BulkPayoutResponse> BulkPayout(BulkPayoutRequest request, string token)
    {
        var encryption =   _encyptionService.GenerateHmacSha512Signature(token, JsonConvert.SerializeObject(request));
       var response = await PostAsync<BulkPayoutResponse>(BaseConstant.BulkPayout, request, token, encryption);
       if(response is null) return new BulkPayoutResponse();
       return response;
    }


    public async Task<VerifyPayoutResponse> VerifyPayout(string reference, string token)
    {
        var response =  await GetAsync<VerifyPayoutResponse>(BaseConstant.VerifyPayout.Replace("reference", reference), null, token);
       if(response is null) return new VerifyPayoutResponse();
       return response;
    }
    

    public async Task<ListAllPayoutResponse> ListAllPayouts(string token)
    {
       var response =  await GetAsync<ListAllPayoutResponse>(BaseConstant.ListAllPayouts, null, token);
       if(response is null) return new ListAllPayoutResponse();
       return response; 
    }


    public async Task<PayoutFeeResponse> PayoutFee(string currency, string amount, string token)
    {
        var payload =  new List<KeyValuePair<string, string>>()
        {
            new("currency", currency),
            new("amount", amount)
        };

        var response = await PostAsync<PayoutFeeResponse>(BaseConstant.PayoutFee, payload, token);
        if(response is null) return new PayoutFeeResponse();
         return response; 
    }

    public async Task<WalletBalanceResponse>WalletBalance(string currency, string token)
    {
        var response =  await GetAsync<WalletBalanceResponse>(BaseConstant.WalletBalance.Replace("{currency}", currency), null, token);
        if(response is null) return new WalletBalanceResponse();
        return response;
    }


  public async Task<WalletTransactionResponse> WalletTransactions(string currency, string token)
  {
    var response = await GetAsync<WalletTransactionResponse>(BaseConstant.WalletTransactions.Replace("{currency}", currency), null, token);
     if(response is null) return new WalletTransactionResponse();
        return response;
  }

    #endregion Payouts


    #region BillsPayment
      
      public async Task<AirtimeProvderResponse> GetAirtimeProviders(string token)
      {
        var response = await GetAsync<AirtimeProvderResponse>(BaseConstant.GetAirtimeProviders, null, token);
        if(response is null) return new AirtimeProvderResponse();
        return response;
      }

      public async Task<AirtimeTopupResponse> AirtimeTopup(AirtimeTopupRequest request, string token)
      {
        var payload = JsonConvert.SerializeObject(request);
        var encryption = _encyptionService.GenerateHmacSha512Signature(token, payload);
       var response =  await PostAsync<AirtimeTopupResponse>(BaseConstant.AirtimeTopup, request, token, encryption);
       if(response is null) return new AirtimeTopupResponse();
       return response;
        
      }


      public async Task<InternetProviderResponse> GetInternetProviders(string token)
      {
         var response = await GetAsync<InternetProviderResponse>(BaseConstant.GetInternetProviders, null, token);
         if(response is null) return new InternetProviderResponse();
         return response;
      }

      public async Task<InternetDataPlansResponse> InternetDataPlans(string provider, string token)
      {
       var response =  await GetAsync<InternetDataPlansResponse>(BaseConstant.InternetDataPlans.Replace("{provider}", provider),null, token);
       if(response is null) return new InternetDataPlansResponse();
       return response;
      }

      public async Task<InternetDataPurchaseResponse> InternetDataPurchase(InternetDataPurchaseRequest request, string token)
      {
        var payload = JsonConvert.SerializeObject(request);
        var encryption = _encyptionService.GenerateHmacSha512Signature(token, payload);
        var response = await PostAsync<InternetDataPurchaseResponse>(BaseConstant.InternetDataPurchase, request, token, encryption);
        if(response is null) return new InternetDataPurchaseResponse();
        return response;
      }

      public async Task<TvProvidersResponse> GetAllTvProviders(string token)
      {
        var response = await GetAsync<TvProvidersResponse>(BaseConstant.TvProviders, null, token);
        if(response is null) return new TvProvidersResponse();
        return response;
      }

      public async Task<TvPackageResponse> TvPackages(string provider, string token)
      {
         var response = await GetAsync<TvPackageResponse>(BaseConstant.TvPackages.Replace("{provider}", provider), null, token);
         if(response is null) return new TvPackageResponse();
         return response;
      }

      public async Task<TvValidateResponse> TvValidate(string provider, string number, string token)
      {
        var payload =  new List<KeyValuePair<string, string>>()
        {
            new("provider", provider),
            new("number", number),
        };

        var response =  await PostAsync<TvValidateResponse>(BaseConstant.TvValidate, payload, token);
        if (response is null) return new TvValidateResponse();
        return response;
      }


      public async Task<TvSubscriptionResponse> TvSubscription(string provider, string number, string code, string reference, string token)
      {
         var payload = new List<KeyValuePair<string, string>>()
         {
            new("provider", provider),
            new("number", number),
            new("code", code),
            new("reference", reference)
         };
           var stringyfiedPayload = JsonConvert.SerializeObject(payload);
         var encryption =  _encyptionService.GenerateHmacSha512Signature(token, stringyfiedPayload);
         var response = await PostAsync<TvSubscriptionResponse>(BaseConstant.TvSubscription, payload, token, encryption);
         if (response is null) return new TvSubscriptionResponse();
         return response;
      }


      public async Task<ElectricityProviderResponse> ElectricityProviders(string token)
      {
        var response = await GetAsync<ElectricityProviderResponse>(BaseConstant.ElectricityProviders, null, token);
        if(response is null) return new ElectricityProviderResponse();
        return response;
      }

      public async Task<ElectricityValidateResponse> ElectricityValidate(string provider, string type, string number, string token)
      {
        var payload = new List<KeyValuePair<string, string>>()
        {
            new("provider", provider),
            new("type", type),
            new("number", number)
        };

         var response =  await PostAsync<ElectricityValidateResponse>(BaseConstant.ElectricityValidate, payload, token);
         if (response is null) return new ElectricityValidateResponse();
         return response;

      }

      public async Task<ElectricityRechargeResponse> ElectricityRecharge(ElectricityRechargeRequest request, string token)
      {
         var payload = JsonConvert.SerializeObject(request);
         var encryption = _encyptionService.GenerateHmacSha512Signature(token, payload);
         var response = await PostAsync<ElectricityRechargeResponse>(BaseConstant.ElectricityRecharge, request, token, encryption);
         if (response is null) return new ElectricityRechargeResponse();
         return response;
      }



    #endregion BillsPayment

}
