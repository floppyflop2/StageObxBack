using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    class JWT
    {
        public string aud { get; set; }
        public string iss { get; set; }
        public int iat { get; set; }
        public int nbf { get; set; }
        public int exp { get; set; }
        public string ver { get; set; }
        public string tid { get; set; }
        public IList<string> amr { get; set; }
        public string oid { get; set; } //user unique ID
        public string upn { get; set; } //user mail
        public string unique_name { get; set; }
        public string sub { get; set; }
        public string puid { get; set; }
        public string family_name { get; set; }
        public string given_name { get; set; }
        public string appid { get; set; }
        public string appidacr { get; set; }
        public string scp { get; set; }
        public string acr { get; set; }
    }
}