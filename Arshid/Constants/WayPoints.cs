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
        public static List<WayPoint> GetWayPointList()
        {
            return JsonConvert.DeserializeObject<List<WayPoint>>(json);
        }

        public static Dictionary<string, WayPoint> GetWayPointDict()
        {
            var pointList = JsonConvert.DeserializeObject<List<WayPoint>>(json);

            Dictionary<string, WayPoint> pointDict = new Dictionary<string, WayPoint>();

            var i = 0;
            foreach (var point in pointList)
            {
                string key = point.Latitude + "" + point.Longitude;
                point.Number = i;
                pointDict[key] = point;

                ++i;
            }

            return pointDict;
        }

        public static string json =
            @"
            [
                {
                    ""Name"":""St:1 3209-2988 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413935,
                    ""Longitude"":39.883795
                },
                {
                    ""Name"":""St:2 3209-2988 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414004,
                    ""Longitude"":39.883813
                },
                {
                    ""Name"":""St:3 3209-2988 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413632,
                    ""Longitude"":39.884153
                },
                {
                    ""Name"":""St:4 3209-2988 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413347,
                    ""Longitude"":39.884587
                },
                {
                    ""Name"":""St:5 3209-2988 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413089,
                    ""Longitude"":39.884928
                },
                {
                    ""Name"":""St:6 3209-2988 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412744,
                    ""Longitude"":39.885298
                },
                {
                    ""Name"":""Street 211, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412485,
                    ""Longitude"":39.885638
                },
                {
                    ""Name"":""St:1 3280-3229 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412140,
                    ""Longitude"":39.885977
                },
                {
                    ""Name"":""St:2 3280-3229 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411853,
                    ""Longitude"":39.886317
                },
                {
                    ""Name"":""St:3 3280-3229 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411680,
                    ""Longitude"":39.886596
                },
                {
                    ""Name"":""St:4 3364-3362 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411335,
                    ""Longitude"":39.887001
                },
                {
                    ""Name"":""St:5 3364-3362 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411076,
                    ""Longitude"":39.887374
                },
                {
                    ""Name"":""St:6 3364-3362 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.410665,
                    ""Longitude"":39.887816
                },
                {
                    ""Name"":""St:1 3486 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.410149,
                    ""Longitude"":39.888419
                },
                {
                    ""Name"":""St:2 3486 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.409972,
                    ""Longitude"":39.888641
                },
                {
                    ""Name"":""St:1 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.409780,
                    ""Longitude"":39.888818
                },
                {
                    ""Name"":""St:1 3660-3646 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.409321,
                    ""Longitude"":39.889427
                },
                {
                    ""Name"":""St:2 3660-3646 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.409113,
                    ""Longitude"":39.889636
                },
                {
                    ""Name"":""St:3 3660-3646 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.408980,
                    ""Longitude"":39.889860
                },
                {
                    ""Name"":""St:4 3660-3646 Rd 56 - Al Jawharah, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.408862,
                    ""Longitude"":39.890082
                },
                {
                    ""Name"":""St:5 3660 Rd 56 - Al Jawharah, Al Mashair, Mecca 24247 8417, Saudi Arabia"",
                    ""Latitude"":21.408720,
                    ""Longitude"":39.890267
                },
                {
                    ""Name"":""Unnamed Road 1, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.410629,
                    ""Longitude"":39.888274
                },
                {
                    ""Name"":""Unnamed Road 2, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.410728,
                    ""Longitude"":39.888349
                },
                {
                    ""Name"":""St:1 3417 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411058,
                    ""Longitude"":39.888547
                },
                {
                    ""Name"":""St:2 3417 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411350,
                    ""Longitude"":39.888252
                },
                {
                    ""Name"":""St:3 3417 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411546,
                    ""Longitude"":39.888092
                },
                {
                    ""Name"":""St:4 3417 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411777,
                    ""Longitude"":39.887868
                },
                {
                    ""Name"":""St:5 3417 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412093,
                    ""Longitude"":39.887550
                },
                {
                    ""Name"":""3321 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412288,
                    ""Longitude"":39.887338
                },
                {
                    ""Name"":""St:1 3208-3275 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412512,
                    ""Longitude"":39.887116
                },
                {
                    ""Name"":""St:2 3208-3275 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412655,
                    ""Longitude"":39.886972
                },
                {
                    ""Name"":""St:3 3208-3275 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412816,
                    ""Longitude"":39.886798
                },
                {
                    ""Name"":""St:4 3208-3275 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412941,
                    ""Longitude"":39.886692
                },
                {
                    ""Name"":""St:5 3208-3275 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413137,
                    ""Longitude"":39.886481
                },
                {
                    ""Name"":""St:1 3248 Rd 62 - Suq Al Arab, Al Mashair, Mecca 24247 8922, Saudi Arabia"",
                    ""Latitude"":21.413262,
                    ""Longitude"":39.886356
                },
                {
                    ""Name"":""St:2 3248 Rd 62 - Suq Al Arab, Al Mashair, Mecca 24247 8922, Saudi Arabia"",
                    ""Latitude"":21.413345,
                    ""Longitude"":39.886282
                },
                {
                    ""Name"":""St:3 3209 Rd 56 - Al Jawharah, Al Mashair, Mecca 24247 8927, Saudi Arabia"",
                    ""Latitude"":21.413478,
                    ""Longitude"":39.886153
                },
                {
                    ""Name"":""St:4 3209 Rd 56 - Al Jawharah, Al Mashair, Mecca 24247 8927, Saudi Arabia"",
                    ""Latitude"":21.413576,
                    ""Longitude"":39.886063
                },
                {
                    ""Name"":""St:1 3060-3155 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413758,
                    ""Longitude"":39.885882
                },
                {
                    ""Name"":""St:2 3060-3155 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413766,
                    ""Longitude"":39.885860
                },
                {
                    ""Name"":""St:3 3060-3155 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413892,
                    ""Longitude"":39.885732
                },
                {
                    ""Name"":""St:4 3060-3155 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414010,
                    ""Longitude"":39.885620
                },
                {
                    ""Name"":""St:5 3060-3155 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414150,
                    ""Longitude"":39.885485
                },
                {
                    ""Name"":""St:6 3060-3155 Rd 62 - Suq Al Arab, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414233,
                    ""Longitude"":39.885399
                },
                {
                    ""Name"":""3382 Rd 62 - Suq Al Arab, Al Mashair, Mecca 24247 8795, Saudi Arabia"",
                    ""Latitude"":21.412269,
                    ""Longitude"":39.887565
                },
                {
                    ""Name"":""St:1 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412381,
                    ""Longitude"":39.887668
                },
                {
                    ""Name"":""St:2 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412477,
                    ""Longitude"":39.887781
                },
                {
                    ""Name"":""St:3 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412574,
                    ""Longitude"":39.887845
                },
                {
                    ""Name"":""St:4 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412664,
                    ""Longitude"":39.887917
                },
                {
                    ""Name"":""St:5 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412757,
                    ""Longitude"":39.888015
                },
                {
                    ""Name"":""St:1 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412759,
                    ""Longitude"":39.888060
                },
                {
                    ""Name"":""St:2 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412740,
                    ""Longitude"":39.888081
                },
                {
                    ""Name"":""St:3 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412694,
                    ""Longitude"":39.888149
                },
                {
                    ""Name"":""St:4 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412435,
                    ""Longitude"":39.888501
                },
                {
                    ""Name"":""St:5 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412263,
                    ""Longitude"":39.888736
                },
                {
                    ""Name"":""St:6 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412098,
                    ""Longitude"":39.888956
                },
                {
                    ""Name"":""St:7 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411854,
                    ""Longitude"":39.889317
                },
                {
                    ""Name"":""St:8 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411636,
                    ""Longitude"":39.889580
                },
                {
                    ""Name"":""St:9 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411550,
                    ""Longitude"":39.889737
                },
                {
                    ""Name"":""St:10 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411417,
                    ""Longitude"":39.889972
                },
                {
                    ""Name"":""St:11 3471-3553 Street 202, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.411199,
                    ""Longitude"":39.890227
                },
                {
                    ""Name"":""St:1 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.412948,
                    ""Longitude"":39.888138
                },
                {
                    ""Name"":""St:2 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413228,
                    ""Longitude"":39.888374
                },
                {
                    ""Name"":""St:3 Street 219, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413587,
                    ""Longitude"":39.888660
                },
                {
                    ""Name"":""St:1 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413702,
                    ""Longitude"":39.888606
                },
                {
                    ""Name"":""St:2 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.413887,
                    ""Longitude"":39.888342
                },
                {
                    ""Name"":""St:3 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414079,
                    ""Longitude"":39.888086
                },
                {
                    ""Name"":""St:4 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414330,
                    ""Longitude"":39.887774
                },
                {
                    ""Name"":""3360 Street 204, Al Mashair, Makkah 24247 9059, Saudi Arabia"",
                    ""Latitude"":21.414555,
                    ""Longitude"":39.887426
                },
                {
                    ""Name"":""Street 225, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414748,
                    ""Longitude"":39.887164
                },
                {
                    ""Name"":""St:1 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414844,
                    ""Longitude"":39.887011
                },
                {
                    ""Name"":""St:2 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415105,
                    ""Longitude"":39.886637
                },
                {
                    ""Name"":""3250 Street 204, Al Mashair, Makkah 24247 9140, Saudi Arabia"",
                    ""Latitude"":21.415259,
                    ""Longitude"":39.886413
                },
                {
                    ""Name"":""Fire Department, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415433,
                    ""Longitude"":39.886175
                },
                {
                    ""Name"":""St:1 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415587,
                    ""Longitude"":39.885960
                },
                {
                    ""Name"":""St:2 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415894,
                    ""Longitude"":39.885579
                },
                {
                    ""Name"":""St:3 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416113,
                    ""Longitude"":39.885235
                },
                {
                    ""Name"":""St:4 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416311,
                    ""Longitude"":39.884970
                },
                {
                    ""Name"":""St:5 204 St, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416463,
                    ""Longitude"":39.884754
                },
                {
                    ""Name"":""St:1 Street 225, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414863,
                    ""Longitude"":39.887220
                },
                {
                    ""Name"":""St:2 Street 225, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.414976,
                    ""Longitude"":39.887304
                },
                {
                    ""Name"":""St:3 Street 225, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415147,
                    ""Longitude"":39.887479
                },
                {
                    ""Name"":""St:4 Street 225, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415388,
                    ""Longitude"":39.887635
                },
                {
                    ""Name"":""St:5 Street 225, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415604,
                    ""Longitude"":39.887831
                },
                {
                    ""Name"":""St:1 3188-3329 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.415806,
                    ""Longitude"":39.887603
                },
                {
                    ""Name"":""3341 Street 206, Al Mashair, Mecca 24247 9199, Saudi Arabia"",
                    ""Latitude"":21.415985,
                    ""Longitude"":39.887343
                },
                {
                    ""Name"":""St:2 3188-3329 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416143,
                    ""Longitude"":39.887135
                },
                {
                    ""Name"":""St:3 3188-3329 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416384,
                    ""Longitude"":39.886794
                },
                {
                    ""Name"":""St:4 3188-3329 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416485,
                    ""Longitude"":39.886636
                },
                {
                    ""Name"":""St:5 3188-3329 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416750,
                    ""Longitude"":39.886302
                },
                {
                    ""Name"":""St:1 3157-3187 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.416862,
                    ""Longitude"":39.886163
                },
                {
                    ""Name"":""St:2 3157-3187 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.417021,
                    ""Longitude"":39.885943
                },
                {
                    ""Name"":""St:3 3157-3187 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.417179,
                    ""Longitude"":39.885708
                },
                {
                    ""Name"":""St:4 3157-3187 Street 206, Al Mashair, Makkah 24247, Saudi Arabia"",
                    ""Latitude"":21.417333,
                    ""Longitude"":39.885483
                }
            ]
            ";
    }
}
