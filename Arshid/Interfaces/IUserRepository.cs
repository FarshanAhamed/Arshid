﻿using Arshid.Web.Models;
using Arshid.Web.Models.InsertModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Interfaces
{
    public interface IUserRepository
    {
        Task<ResultData> SaveUserLocation (UserLocationInsertModel userLocation );
        Task<ResultData<User>> GetUserGroupDetails(int userID);
        Task<ResultData<User>> GetUserDetails(int userID);
        Task<ResultData<List<Group>>> GenerateHeatMap();
        Task<ResultData<List<WayPoint>>> GenerateZonalHeatMap();
        Task<ResultData<Stats>> GetStats();
        Task<ResultData<List<Group>>> GetAllGroups();
        Task<ResultData> DeleteAllUserLocations();
        Task<ResultData> SaveMultipleUserLocations(
            List<UserLocation> userLocations);
        Task<ResultData<IEnumerable<User>>> GetGroupUsers(int groupID);
        Task<ResultData> ResetDatabase(string newsql);
    }
}
