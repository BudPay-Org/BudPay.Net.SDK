namespace BudPay.Net.SDK.DataTransfers;

public class ElectricityRechargeResponse
{
     public bool success { get; set; }
        public string code { get; set; }
        public string message { get; set; }
        public ElectricyRechargeData data { get; set; }
}


    public class ElectricyRechargeData
    {
        public string orderNo { get; set; }
        public string reference { get; set; }
        public string status { get; set; }
        public string errorMsg { get; set; }
        public string purchased_code { get; set; }
        public string units { get; set; }
    }

