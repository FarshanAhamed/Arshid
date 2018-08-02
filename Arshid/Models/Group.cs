using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Models
{
    public class Group
    {
        public int? GroupID { get; set; }
        public string Name { get; set; }

        public string LocationName { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public string GroupContact { get; set; }
        public string Country { get; set; }


        public int UserCount { get; set; }

        [JsonIgnore]
        public int TotalCount { get; set; }

        [JsonIgnore]
        public Group LocatedGroup { get; set; }
    }
}
