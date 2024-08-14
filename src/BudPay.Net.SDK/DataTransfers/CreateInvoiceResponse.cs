namespace BudPay.Net.SDK.DataTransfers;

public class CreateInvoiceResponse
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
    /// Data related to the invoice.
    /// </summary>
    public List<InvoiceData> Data { get; set; }
}


public class InvoiceData
{
    /// <summary>
    /// Unique identifier for the invoice.
    /// </summary>
    public int InvoiceId { get; set; }

    /// <summary>
    /// Reference identifier for the invoice.
    /// </summary>
    public string RefId { get; set; }

    /// <summary>
    /// Paycode associated with the invoice.
    /// </summary>
    public string Paycode { get; set; }

    /// <summary>
    /// Redirect link for the invoice.
    /// </summary>
    public string RedirectLink { get; set; }
}
