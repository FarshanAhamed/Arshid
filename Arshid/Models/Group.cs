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

        public int UserCount { get; set; }
        public WayPoint NextLocation { get; set; }

        public DateTime? AddedDate { get; set; }

        [JsonIgnore]
        public int TotalCount { get; set; }

        [JsonIgnore]
        public Group LocatedGroup { get; set; }
    }
}
