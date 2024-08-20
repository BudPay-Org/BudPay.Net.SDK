namespace BudPay.Net.SDK.DataTransfers;

public class InternetDataPlansResponse
{
    public bool success { get; set; }
    public string code { get; set; }
    public string message { get; set; }
    public List<InternetDataPlans> data { get; set; }
}

    public class InternetDataPlans
    {
        public int id { get; set; }
        public string name { get; set; }
        public string amount { get; set; }
    }


