using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Models
{
    public class WayPoint
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Name { get; set; }

        [JsonIgnore]
        public int Number { get; set; }
    }
}
