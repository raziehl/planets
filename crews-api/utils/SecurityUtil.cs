namespace crews_api.utils;
using bCrypt = BCrypt.Net.BCrypt;

static class SecurityUtil {

  public static String PrivateKey { get; set; }

  static SecurityUtil() {
    String? private_key = Environment.GetEnvironmentVariable("PRIVATE_KEY");
    PrivateKey = private_key != null && private_key != "" ? private_key : throw new Exception("Security Environment Variables not set.");
  }

  static String HashPassword(String value) {
    return bCrypt.HashPassword(value);
  }
}