namespace BudPay.Net.SDK.DataTransfers;

public class ElectricityValidateResponse
{
     public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public ElectricityValidateData data { get; set; }
}

    public class ElectricityValidateData
    {
        public string provider { get; set; }
        public string number { get; set; }
        public string type { get; set; }
        public string Customer_Name { get; set; }
    }

  


