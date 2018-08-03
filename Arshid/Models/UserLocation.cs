using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Models
{
    public class UserLocation
    {
        public int? UserLocationID { get; set; }
        public int? UserID { get; set; }
        public int? GroupID { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
