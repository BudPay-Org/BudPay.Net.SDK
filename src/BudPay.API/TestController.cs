using System.Security.Cryptography;
using BudPay.Net.SDK;
using BudPay.Net.SDK.DataTransfers;
using Microsoft.AspNetCore.Mvc;

namespace BudPay.API;

[Route("api/[controller]")]
[ApiController]
public class TestController : ControllerBase
{
    private readonly BudPayApi _budPayApi;

    public TestController(BudPayApi budPayApi)
    {
        _budPayApi = budPayApi;
    }


        [HttpGet("generate-aes-key-iv")]
        public IActionResult GenerateAesKeyAndIV()
        {
            using (Aes aes = Aes.Create())
            {
                aes.KeySize = 256; // Set the key size to 256 bits (32 bytes)
                aes.GenerateKey();  // Generate a new key
                aes.GenerateIV();   // Generate a new IV (Initialization Vector)

                var keyIvPair = new 
                {
                    Key = Convert.ToBase64String(aes.Key),
                    IV = Convert.ToBase64String(aes.IV)
                };

                return Ok(keyIvPair);
            }
        }



  [HttpPost("card-transaction")]
  public async Task<IActionResult> TestingCardTransaction([FromBody] S2SInitializeTransactionRequest request)
  {

   var response =   await  _budPayApi.AcceptPaymentService.V2InitializeTransactionS2S(request);

   return  Ok(response);
  }
}


