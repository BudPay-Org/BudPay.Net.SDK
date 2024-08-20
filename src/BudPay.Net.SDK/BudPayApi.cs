using BudPay.Net.SDK.BillPayments;
using BudPay.Net.SDK.Interfaces;
using BudPay.Net.SDK.Payouts;
using BudPay.Net.SDK.Transactions;

namespace BudPay.Net.SDK;



public interface IBudPayApi
{
  string Token { get; set; }
  IAcceptPaymentService AcceptPaymentService { get; }
  IPayoutService PayoutService { get; }

  IBillPaymentService BillPaymentService { get; }
}



public class BudPayApi : IBudPayApi
{
    public string Token { get; set; }
    private IAcceptPaymentService _acceptPayments;
    private IPayoutService _payoutService;
    private IBillPaymentService _billPaymentService;

    

    public IAcceptPaymentService AcceptPaymentService
    {
        get
        {
           if(_acceptPayments == null) 
           _acceptPayments = new AcceptPaymentService(Token);  
           return _acceptPayments;  
        }
    }

    public IPayoutService PayoutService
    {
        get
        {
           if(_payoutService == null)
           _payoutService = new PayoutService(Token);
           return _payoutService;
        }
    }

    public IBillPaymentService BillPaymentService
    {
        get
        {
            if (_billPaymentService == null)
            _billPaymentService = new BillPaymentService(Token);
            return _billPaymentService;
        }
    }
   
}


