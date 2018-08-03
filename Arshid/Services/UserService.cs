using Arshid.Web.Constants;
using Arshid.Web.Interfaces;
using Arshid.Web.Models;
using Arshid.Web.Models.InsertModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Arshid.Web.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<ResultData<User>> GetUserLocation(int userId)
        {

            try
            {
                var userDetails = await _userRepository.GetUserDetails(userId);
                return userDetails;
            }
            catch (Exception ex)
            {
                return new ResultData<User>
                {
                    Status = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ResultData<User>> GetGroupLocation(int userId)
        {

            try
            {
                var userDetails = await _userRepository.GetUserGroupDetails(userId);
                return userDetails;
            }
            catch (Exception ex)
            {
                return new ResultData<User>
                {
                    Status = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ResultData<User>> SaveUserLocation(UserLocationInsertModel userLocation)
        {
            try
            {
                var userDetails = await _userRepository.GetUserGroupDetails(userLocation.UserID.GetValueOrDefault());
                userLocation.GroupID = userDetails.Data.GroupID.GetValueOrDefault();
                var result = await _userRepository.SaveUserLocation(userLocation);
                if (!result.Status)
                {
                    return new ResultData<User>
                    {
                        Status = false,
                        Message = result.Message
                    };
                }

                // Get the next waypoint
                var waypointList = WayPoints.GetWayPointList();
                var waypointDict = WayPoints.GetWayPointDict();

                string currentKey = userLocation.Latitude + "" + userLocation.Longitude;
                int currentIndex = waypointDict[currentKey].Number;

                if (currentIndex + 1 < waypointList.Count)
                    userDetails.Data.UserGroup.NextLocation = waypointList[currentIndex + 1];
                else
                    userDetails.Data.UserGroup.NextLocation = waypointList[0];
                
                return userDetails;
            }
            catch(Exception ex)
            {
                return new ResultData<User>
                {
                    Status = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<ResultData<List<Group>>> GenerateHeatmap()
        {
            try
            {
                var userDetails = await _userRepository.GenerateHeatMap();
                return userDetails;
            }
            catch (Exception ex)
            {
                return new ResultData<List<Group>>
                {
                    Status = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<ResultData<Stats>> GetStats()
        {
            try
            {
                var result = await _userRepository.GetStats();

                Stats stats = result.Data;
                stats.AreaCount = WayPoints.GetWayPointList().Count;
                stats.HiglyActivateAreaCount = stats.AreaCount / 10;

                return result;
            }
            catch (Exception ex)
            {
                return new ResultData<Stats>
                {
                    Status = false,
                    Message = ex.Message
                };
            }

        }


        public async Task<ResultData<IEnumerable<User>>> GetGroupUsers(int groupId)
        {

            try
            {
                var users = await _userRepository.GetGroupUsers(groupId);
                return users;
            }
            catch (Exception ex)
            {
                return new ResultData<IEnumerable<User>>
                {
                    Status = false,
                    Message = ex.Message
                };
            }

        }


        public async Task<ResultData> ResetDatabase()
        {
            try
            {
                var assembly = Assembly.GetExecutingAssembly();
                string sql;
                using (Stream stream = assembly.GetManifestResourceStream("Arshid.Web.Constants.ResetDatabase.sql"))
                using (StreamReader reader = new StreamReader(stream))
                {
                    sql = reader.ReadToEnd();
                }

                var result = await _userRepository.ResetDatabase(sql);
                return result;
            }
            catch(Exception ex)
            {
                return new ResultData
                {
                    Status = false,
                    Message = ex.Message
                };
            }
            
        }

    }
}
