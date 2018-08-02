using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Models
{
    public class User
    {
        public int? UserID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PassportNumber { get; set; }

        public double? Latitiude { get; set; }
        public double? Longitude { get; set; }

        [JsonIgnore]
        public int? GroupID { get; set; }

        public Group UserGroup { get; set; }
    }
}
