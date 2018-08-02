using Arshid.Web.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Constants
{

    public class WayPoints
    {
        public static string json =
            @"
                []
            ";

        public static List<WayPoint> GetWayPointList()
        {
            return JsonConvert.DeserializeObject<List<WayPoint>>(json);
        }

        public static Dictionary<string, WayPoint> GetWayPointDict()
        {
            var pointList = JsonConvert.DeserializeObject<List<WayPoint>>(json);

            Dictionary<string, WayPoint> pointDict = new Dictionary<string, WayPoint>();
            foreach (var point in pointList)
            {
                string key = point.Latitude + "" + point.Longitude;
                pointDict[key] = point;
            }

            return pointDict;
        }
    }
}
