
#pragma warning disable SYSLIB0041
namespace crews_api.utils;
using bCrypt = BCrypt.Net.BCrypt;
using System.Security.Cryptography;
using System.Text;

static class SecurityUtil
{

  public static String PrivateKey { get; set; }

  static SecurityUtil()
  {
    String? private_key = Environment.GetEnvironmentVariable("PRIVATE_KEY");
    PrivateKey = private_key != null && private_key.Length > 0 ? private_key : throw new Exception("Security Environment Variables not set.");
  }

  public static String HashEncryptPassword(String value)
  {
    return bCrypt.HashPassword(Encrypt(value));
  }

  public static bool VerifyPassword(String password, String passwordHash) {
    return bCrypt.Verify(Encrypt(password), passwordHash);
  }

  private static string Encrypt(string clearText)
  {
    byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
    using (Aes encryptor = Aes.Create())
    {
      Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(PrivateKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
      encryptor.Key = pdb.GetBytes(32);
      encryptor.IV = pdb.GetBytes(16);
      using (MemoryStream ms = new MemoryStream())
      {
        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
        {
          cs.Write(clearBytes, 0, clearBytes.Length);
          cs.Close();
        }
        clearText = Convert.ToBase64String(ms.ToArray());
      }
    }
    return clearText;
  }
  
  private static string Decrypt(string cipherText)
  {
    cipherText = cipherText.Replace(" ", "+");
    byte[] cipherBytes = Convert.FromBase64String(cipherText);
    using (Aes encryptor = Aes.Create())
    {

      Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(PrivateKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
      encryptor.Key = pdb.GetBytes(32);
      encryptor.IV = pdb.GetBytes(16);
      using (MemoryStream ms = new MemoryStream())
      {
        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
        {
          cs.Write(cipherBytes, 0, cipherBytes.Length);
          cs.Close();
        }
        cipherText = Encoding.Unicode.GetString(ms.ToArray());
      }
    }
    return cipherText;
  }
}