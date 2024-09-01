using System.Security.Cryptography;
using System.Text;
using BudPay.Net.SDK.DataTransfers;
using BudPay.Net.SDK.Interfaces;
using Newtonsoft.Json;

namespace BudPay.Net.SDK;

public class EncyptionService : IEncyptionService
{
    public  string EncryptCard(CardDetailsRequest cardData, byte[] key, byte[] iv)
    {
        var cardDataJson = JsonConvert.SerializeObject(cardData);

        using (Aes aes = Aes.Create())
        {
            aes.Key = key;
            aes.IV = iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            {
                byte[] encryptedBytes;
                using (var ms = new MemoryStream())
                {
                    using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        using (var sw = new StreamWriter(cs))
                        {
                            sw.Write(cardDataJson);
                        }
                        encryptedBytes = ms.ToArray();
                    }
                }
                return Convert.ToBase64String(encryptedBytes);
            }
        }     
    }

    public string GenerateHmacSha512Signature(string publicKey, string payload)
    {
        using (var hmac = new HMACSHA512(Encoding.UTF8.GetBytes(publicKey)))
        {
            byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(payload));
            return BitConverter.ToString(hash).Replace("-", "").ToLower(); 
           
        }
    }


    public string EncryptCardData(string cardDataJson, string publicKey, string reference)
    {
        using (var aes = Aes.Create())
        {
            aes.KeySize = 256;
            aes.BlockSize = 128;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;

            // Convert publicKey and reference to byte arrays
            byte[] key = Encoding.UTF8.GetBytes(publicKey);
            byte[] iv = Encoding.UTF8.GetBytes(reference.Substring(0, 16)); // Ensure the IV is 16 bytes

            aes.Key = key;
            aes.IV = iv;

            // Encrypt the card data
            using (var encryptor = aes.CreateEncryptor(aes.Key, aes.IV))
            using (var ms = new MemoryStream())
            using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(cardDataJson);
                cs.Write(plainTextBytes, 0, plainTextBytes.Length);
                cs.FlushFinalBlock();

                byte[] cipherTextBytes = ms.ToArray();
                return Convert.ToHexString(cipherTextBytes).ToLower();
            }
        }
    }

}
