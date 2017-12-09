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

        public virtual object Get(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual int Check(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual object Add(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Remove(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Modify(object obj)
        {
            throw new Exception("Not implemented for this object");
        }

        public virtual void Dispose()
        {

        }

        /*
        public Boolean CheckToken(String encodedtoken)
        {
            //Code based on: https://github.com/jasonjoh/office365-azure-guides/blob/master/ValidatingYourToken.md

            if (string.IsNullOrEmpty(encodedtoken))
            {
                Console.WriteLine("Token missing.");
                return false;
            }

            string[] tokenParts = encodedtoken.Split('.');
            if (tokenParts.Length < 3)
            {
                Console.WriteLine("JWT must have three parts.");
                return false;
            }

            string header = PrettyPrintJson(Base64UrlEncoder.Decode(tokenParts[0]));

            string payload = PrettyPrintJson(Base64UrlEncoder.Decode(tokenParts[1]));

            JWT jwtpayload = JsonConvert.DeserializeObject<JWT>(payload);
            string mail = jwtpayload.upn;
            //TO DO: follow up with database crosscheck and issue date / validity duration check

            //If validity is later than current date or if the token is already expired
            if (jwtpayload.nbf > DateTime.Now.Ticks || jwtpayload.exp < DateTime.Now.Ticks)
            {
                return false;
            }

            try
            {
                using (var db = new DBModel())
                {
                    //Get the student with the same mail (code assumes the student exists already) 
                    var result = db.Students.Where(s => s.StudentEmail == mail);

                    JWT StudentToken = JsonConvert.DeserializeObject<JWT>(result.FirstOrDefault().StudentToken);

                    //check if the unique ID is the same for both tokens
                    if (jwtpayload.oid != StudentToken.oid)
                    {
                        return false;
                    }

                    //Overwrite the token in the db
                    result.FirstOrDefault().StudentToken = payload;
                    Modify(result);
                    return true;

                }
            }
            catch (Exception e)
            {
                //logger.Error(e.Message + "Check Error");
                throw new Exception(e.Message);
            }



        }

    */
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