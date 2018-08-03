using Arshid.Web.Models;
using Arshid.Web.Models.InsertModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Interfaces
{
    public interface IUserService
    {
        Task<ResultData<User>> SaveUserLocation(UserLocationInsertModel userLocation);
        Task<ResultData<User>> GetUserLocation(int userId );
        Task<ResultData<User>> GetGroupLocation(int userId);
        Task<ResultData<List<Group>>> GenerateHeatmap();
        Task<ResultData<Stats>> GetStats();
        Task<ResultData> GenerateUserLocations();
    }
}
