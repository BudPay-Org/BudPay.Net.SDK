using BudPay.Net.SDK.Collections;
using BudPay.Net.SDK.Interfaces;

namespace BudPay.Net.SDK;



public interface IBudPayApi
{
  IAcceptPaymentService AcceptPaymentService { get; }
}



public class BudPayApi : IBudPayApi
{
    private string _token;
    private IAcceptPaymentService _acceptPayments;

    public BudPayApi(string token)
    {
        _token = token;
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
}
