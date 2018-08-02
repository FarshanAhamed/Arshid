using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Models
{
    public class Group
    {
        public string Name { get; set; }

        public double? Latitude { get; set; }
        public double? Longitude { get; set; }

        [JsonIgnore]
        public int TotalCount { get; set; }
    }
}
