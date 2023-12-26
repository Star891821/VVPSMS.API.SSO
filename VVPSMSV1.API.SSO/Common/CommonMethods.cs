using Microsoft.AspNetCore.Mvc;
using VVPSMSV1.API.SSO.Service.DataManagers;

namespace VVPSMSV1.API.SSO.Common
{
    public static class CommonMethods
    {

        public static string EncryptPassword(string encryptionKey,string clearText)
        {
            StringEncryptionService a = new StringEncryptionService();
            var result = a.EncryptAsync(clearText, encryptionKey);
            string base64String = Convert.ToBase64String(result.Result, 0, result.Result.Length);
            return base64String;
        }

        public static string DecryptPassword(string encryptionKey, string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            StringEncryptionService a = new StringEncryptionService();
            var result = a.DecryptAsync(cipherBytes, encryptionKey);
            return result.Result;
        }
    }
}
