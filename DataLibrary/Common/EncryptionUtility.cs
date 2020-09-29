using System;
using System.Security.Cryptography;

namespace DataLibrary.Common
{
  public class EncryptionUtility
  {
    private static string CreateSalt(int size = 20)
    {
      // Generate a cryptographic random number using the cryptographic 
      // service provider
      RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();

      byte[] buff = new byte[size];

      rng.GetBytes(buff);

      // Return a Base64 string representation of the random number
      return Convert.ToBase64String(buff);
    }

    public static string HashedText(string password, out string salt)
    {
      salt = CreateSalt();

      string stringDataToHash = $"{password}{salt}";

      // Create a new instance of the hash crypto service provider.
      HashAlgorithm hashAlg = new SHA256CryptoServiceProvider();
      
      // Convert the data to hash to an array of Bytes.
      byte[] bytValue = System.Text.Encoding.UTF8.GetBytes(stringDataToHash);
      
      // Compute the Hash. This returns an array of Bytes.
      byte[] bytHash = hashAlg.ComputeHash(bytValue);
      
      // Optionally, represent the hash value as a base64-encoded string, 
      // For example, if you need to display the value or transmit it over a network.
      string base64 = Convert.ToBase64String(bytHash);

      return base64;
    }

  }
}
