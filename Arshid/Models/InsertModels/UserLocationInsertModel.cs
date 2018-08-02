using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Models.InsertModels
{
    public class UserLocationInsertModel
    {
        public int? UserID { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int GroupID { get; set; }
    }
}
