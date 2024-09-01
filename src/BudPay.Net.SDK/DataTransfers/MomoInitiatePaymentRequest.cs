namespace BudPay.Net.SDK.DataTransfers;

public class MomoInitiatePaymentRequest
{
    /// <summary>
    /// Set value to payment amount. No decimal places allowed.
    /// </summary>
    public string amount { get; set; }

    /// <summary>
    /// Set value to checkout currency (only KES currently supported).
    /// </summary>
    public string currency { get; set; }

    /// <summary>
    /// Set value to mobile money provider.
    /// </summary>
    public string bankName { get; set; }

    /// <summary>
    /// Set value to payee's phone number.
    /// </summary>
    public string phone { get; set; }

    /// <summary>
    /// Set value to payment details or purpose.
    /// </summary>
    public string description { get; set; }

    /// <summary>
    /// Set value to your unique reference number.
    /// </summary>
    public string reference { get; set; }

    /// <summary>
    /// Set value to preferred URL to get notified of payment status with key details to identify payment.
    /// </summary>
    public string callbackUrl { get; set; }

}
