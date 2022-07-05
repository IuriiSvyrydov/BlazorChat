using System.Security.Cryptography;
using System.Text;

namespace BlazorChat.Common.Infrastructure;

public  class PasswordEncryptor
{
    public static string Encrypt(string password)
    {
        using var md5 = MD5.Create();
        byte[]inputBytes = Encoding.UTF8.GetBytes(password);
        byte[]hashBytes = md5.ComputeHash(inputBytes);
        return Convert.ToHexString(hashBytes);
    }
}