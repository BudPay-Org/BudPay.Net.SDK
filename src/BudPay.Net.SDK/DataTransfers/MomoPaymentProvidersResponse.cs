namespace BudPay.Net.SDK.DataTransfers;

public class MomoPaymentProvidersResponse
{
    public bool status { get; set; }
    public string message { get; set; }
    public List<string> banks { get; set; }
}

