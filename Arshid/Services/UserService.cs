using Arshid.Web.Interfaces;
using Arshid.Web.Models;
using Arshid.Web.Models.InsertModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
