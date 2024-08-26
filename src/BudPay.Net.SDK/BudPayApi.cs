using BudPay.Net.SDK.BillPayments;
using BudPay.Net.SDK.Interfaces;
using BudPay.Net.SDK.Payouts;
using BudPay.Net.SDK.Transactions;

namespace BudPay.Net.SDK;



// public interface IBudPayApi
// {
//   IAcceptPaymentService AcceptPaymentService { get; }
//   IPayoutService PayoutService { get; }

//   IBillPaymentService BillPaymentService { get; }
// }



public class BudPayApi 
{
    public readonly string _token;
    private IAcceptPaymentService _acceptPayments;
    private IPayoutService _payoutService;
    private IBillPaymentService _billPaymentService;

    
    public BudPayApi(string token)
    {
        _token  = token;
    }

    public IAcceptPaymentService AcceptPaymentService
    {
        get
        {
           if(_acceptPayments == null) 
           _acceptPayments = new AcceptPaymentService(_token);  
           return _acceptPayments;  
        }
    }

    public IPayoutService PayoutService
    {
        get
        {
           if(_payoutService == null)
           _payoutService = new PayoutService(_token);
           return _payoutService;
        }
    }

    public IBillPaymentService BillPaymentService
    {
        get
        {
            if (_billPaymentService == null)
            _billPaymentService = new BillPaymentService(_token);
            return _billPaymentService;
        }
    }
   
}


