namespace BudPay.Net.SDK.DataTransfers;

public class MomoInitiatePaymentRequest
{
    /// <summary>
    /// Set value to payment amount. No decimal places allowed.
    /// </summary>
    public string Amount { get; set; }

    /// <summary>
    /// Set value to checkout currency (only KES currently supported).
    /// </summary>
    public string Currency { get; set; }

    /// <summary>
    /// Set value to mobile money provider.
    /// </summary>
    public string BankName { get; set; }

    /// <summary>
    /// Set value to payee's phone number.
    /// </summary>
    public string Phone { get; set; }

    /// <summary>
    /// Set value to payment details or purpose.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Set value to your unique reference number.
    /// </summary>
    public string Reference { get; set; }

    /// <summary>
    /// Set value to preferred URL to get notified of payment status with key details to identify payment.
    /// </summary>
    public string CallbackUrl { get; set; }

}
