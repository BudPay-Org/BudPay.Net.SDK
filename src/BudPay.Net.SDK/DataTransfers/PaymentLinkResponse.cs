namespace BudPay.Net.SDK.DataTransfers;

public class PaymentLinkResponse
{
    /// <summary>
    /// Indicates if the request was successful.
    /// </summary>
    public bool Success { get; set; }

    /// <summary>
    /// Message related to the response.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Data related to the payment link.
    /// </summary>
    public List<PaymentLinkData> Data { get; set; }
}

public class PaymentLinkData
{
    /// <summary>
    /// Reference identifier for the payment link.
    /// </summary>
    public string RefId { get; set; }

    /// <summary>
    /// Paycode associated with the payment link.
    /// </summary>
    public string Paycode { get; set; }

    /// <summary>
    /// Payment link URL.
    /// </summary>
    public string PaymentLink { get; set; }
}
