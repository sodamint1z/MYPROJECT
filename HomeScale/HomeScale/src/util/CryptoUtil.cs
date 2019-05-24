using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaknampoScale.src.util
{
    public static class CryptoUtil
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private static string salt = "*1234567890!@#$%^&*()14344*";
        public static string encrypt(string text)
        {
            try
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                byte[] toEncryptArray = Encoding.UTF8.GetBytes(text);

                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(salt));
                hashmd5.Clear();
                TripleDESCryptoServiceProvider tripleDesProvider = new TripleDESCryptoServiceProvider();
                tripleDesProvider.Key = keyArray;
                tripleDesProvider.Mode = CipherMode.ECB;
                tripleDesProvider.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tripleDesProvider.CreateEncryptor();

                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                return Convert.ToBase64String(resultArray, 0, resultArray.Length);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
            
        }

        public static string decrypt(string text)
        {
            try
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                byte[] toEncryptArray = Convert.FromBase64String(text);

                byte[] keyArray = hashmd5.ComputeHash(Encoding.UTF8.GetBytes(salt));

                hashmd5.Clear();
                TripleDESCryptoServiceProvider tripleDesProvider = new TripleDESCryptoServiceProvider();
                tripleDesProvider.Key = keyArray;
                tripleDesProvider.Mode = CipherMode.ECB;
                tripleDesProvider.Padding = PaddingMode.PKCS7;

                ICryptoTransform cTransform = tripleDesProvider.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                tripleDesProvider.Clear();

                return Encoding.UTF8.GetString(resultArray);
            }
            catch (Exception ex)
            {
                return string.Empty;
            }
        }

        public static string encodeTo64(string toEncode)
        {
            var returnValue = "";
            try
            {
                if (Util.isNotEmpty(toEncode))
                {
                    var toEncodeAsBytes = Encoding.ASCII.GetBytes(toEncode);
                    returnValue = System.Convert.ToBase64String(toEncodeAsBytes);
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                return toEncode;
            }
            return toEncode;
        }

        public static string decodeFrom64(string encodedData)
        {
            var returnValue = "";
            try
            {
                if (Util.isNotEmpty(encodedData))
                {
                    var encodedDataAsBytes = System.Convert.FromBase64String(encodedData);
                    returnValue = Encoding.ASCII.GetString(encodedDataAsBytes);
                    return returnValue;
                }
            }
            catch (Exception ex)
            {
                return encodedData;
            }
            return encodedData;
        }
    }
}
