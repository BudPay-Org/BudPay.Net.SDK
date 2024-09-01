namespace BudPay.Net.SDK.DataTransfers;

public class TvValidateResponse
{
  public string code { get; set; }
    public CustomerContent content { get; set; }
}

public class CustomerContent
{
    public string Customer_Name { get; set; }
    public string Status { get; set; }
    public string Due_Date { get; set; }
    public string Customer_Number { get; set; }
    public string Customer_Type { get; set; }
    public string Current_Bouquet { get; set; }
    public string Current_Bouquet_Code { get; set; }
    public decimal Renewal_Amount { get; set; }
}


