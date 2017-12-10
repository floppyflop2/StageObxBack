using System;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Globalization;

namespace BusinessLogic
{
    public abstract class BusinessLogic : IDisposable
    {
        public virtual object GetAll()
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual object Get(string id)
        {
            throw new Exception("Not implemented for this object");
        }
        
        public virtual object Add(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Remove(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Modify(object obj, string id)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Dispose()
        {

        }

        public static string PrettyPrintJson(string jsonString)
        {
            try
            {
                dynamic parsedJson = JsonConvert.DeserializeObject(jsonString);
                return JsonConvert.SerializeObject(parsedJson, Newtonsoft.Json.Formatting.Indented);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        static class Base64UrlEncoder
        {
            static char Base64PadCharacter = '=';
            static string DoubleBase64PadCharacter = String.Format(CultureInfo.InvariantCulture, "{0}{0}", Base64PadCharacter);
            static char Base64Character62 = '+';
            static char Base64Character63 = '/';
            static char Base64UrlCharacter62 = '-';
            static char Base64UrlCharacter63 = '_';

            public static byte[] DecodeBytes(string arg)
            {
                string s = arg;
                s = s.Replace(Base64UrlCharacter62, Base64Character62); // 62nd char of encoding
                s = s.Replace(Base64UrlCharacter63, Base64Character63); // 63rd char of encoding
                switch (s.Length % 4) // Pad 
                {
                    case 0:
                        break; // No pad chars in this case
                    case 2:
                        s += DoubleBase64PadCharacter; break; // Two pad chars
                    case 3:
                        s += Base64PadCharacter; break; // One pad char
                    default:
                        throw new ArgumentException("Illegal base64url string!", arg);
                }
                return Convert.FromBase64String(s); // Standard base64 decoder
            }

            public static string Decode(string arg)
            {
                return Encoding.UTF8.GetString(DecodeBytes(arg));
            }
        }
    }
}