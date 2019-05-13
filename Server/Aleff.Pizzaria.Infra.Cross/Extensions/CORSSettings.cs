using System;
using System.Collections.Generic;
using System.Text;

namespace Aleff.Pizzaria.Infra.Cross.Extensions
{
    public class CORSSettings
    {
        public string[] Origins { get; set; }
        public string[] Methods { get; set; }
        public string[] Headers { get; set; }
        public bool AllowCredentials { get; set; }

        public CORSSettings()
        {
        }

        public CORSSettings Default()
        {
            Origins = new string[] { "*" };
            Methods = new string[] { "*" };
            Headers = new string[] { "*" };
            AllowCredentials = true;

            return this;
        }
    }
}
