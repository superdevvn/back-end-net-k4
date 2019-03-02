using System;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Utilities
{
    public class Utility
    {
        public static void CloneObject(object des, object src)
        {
            foreach (PropertyInfo propertyInfo in des.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance))
            {
                if (src.GetType().GetProperty(propertyInfo.Name, BindingFlags.Public | BindingFlags.Instance) != null)
                {
                    var value = src.GetType().GetProperty(propertyInfo.Name).GetValue(src, null);
                    propertyInfo.SetValue(des, value, null);
                }
            }
        }

        public static string MD5Encrypt(string password)
        {
            var md5Hasher = new MD5CryptoServiceProvider();
            var encoder = new UTF8Encoding();
            var hashedBytes = md5Hasher.ComputeHash(encoder.GetBytes(password));
            return hashedBytes.Aggregate(string.Empty, (current, b) => current + b.ToString("x2"));
        }

        //public static string Encrypt(Dictionary<string,string> data)
        //{
        //    return new JavaScriptSerializer().Serialize(data);
        //}

        //public static object Decrypt(string data)
        //{
        //    return JsonConvert.DeserializeObject<Dictionary<string, string>>(data);
        //}

        //public static string Encrypt(string data)
        //{
        //    return data;
        //}

        //public static string Decrypt(string data)
        //{
        //    return data;
        //}

        public static string Encrypt(CustomIdentity customIdentity)
        {
            return JWT.GenerateToken(customIdentity);
        }

        public static CustomIdentity Decrypt(string token)
        {
            return JWT.AuthenticateJwtToken(token);
        }

        public static CustomIdentity CurrentIdentity
        {
            get
            {
                var token = HttpContext.Current.Request.Headers.Get("Token").ToString();
                return Decrypt(token);
            }
        }

        public static Guid UserId
        {
            get
            {
                return CurrentIdentity.UserId;
            }
        }

        public static bool IsMasterUser
        {
            get
            {
                return CurrentIdentity.IsMasterUser;
            }
        }

        public static Guid ClientId
        {
            get
            {
                return CurrentIdentity.ClientId;
            }
        }

        public static string ClientCode
        {
            get
            {
                return CurrentIdentity.ClientCode;
            }
        }

        public static bool IsMasterClient
        {
            get
            {
                return CurrentIdentity.IsMasterClient;
            }
        }

        public static string Username
        {
            get
            {
                return CurrentIdentity.Username;
            }
        }
    }
}