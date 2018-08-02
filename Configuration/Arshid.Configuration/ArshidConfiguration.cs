using System;
using System.Collections.Generic;
using System.Text;

namespace Arshid.Configuration
{
    public class ArshidConfiguration
    {
        public string SqlConnectionString { get; set; }
        public string TokenIssuer { get; set; }
        public string TokenAudience { get; set; }
        public string JwtSecretToken { get; set; }
        public string APIKey { get; set; }
        public bool APIKeyEnabled { get; set; }
        public string BaseUrl { get; set; }        
    }
}
