using BudPay.Net.SDK.DataTransfers;

namespace BudPay.Net.SDK.Interfaces;

public interface IEncyptionService
{
    string EncryptCard(CardDetailsRequest cardData, byte[] key, byte[] iv);
    string GenerateHmacSha512Signature(string secretKey, string payload);
}
