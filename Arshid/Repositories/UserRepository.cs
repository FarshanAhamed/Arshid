using Arshid.Configuration;
using Arshid.Web.Interfaces;
using Arshid.Web.Models;
using Arshid.Web.Models.InsertModels;
using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Arshid.Web.Repositories
{
    public class UserRepository : IUserRepository
    {
        private ConnectionManager _connectionManager;

        public UserRepository(IOptions<ArshidConfiguration> options)
        {
            _connectionManager = new ConnectionManager(options);
        }

        public async Task<ResultData<User>> GetUserDetails(int userID)
        {
            ResultData<User> resultData = new ResultData<User>();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                                        SELECT 
                                        gu.UserID,
                                        gu.Name,
                                        gu.Address,
                                        PassportNumber,
                                        gu.GroupID,
                                        g.Name AS GroupName
                                        FROM 
                                        GlobalUsers gu
                                        LEFT JOIN Groups g ON g.GroupID = gu.GroupID
                                        WHERE gu.UserID = @UserID;
                                  ";

                    var result = await dbConnection.QueryAsync<User>(sql, new { UserID = userID });
                    User user = result.First();

                    string groupSql = @"
                                        SELECT Latitude, Longitude FROM userlocations
                                        WHERE userid=@UserID AND
                                         AddedDate = 
                                         (SELECT max(AddedDate) FROM userlocations WHERE userid=@UserID);
                                  ";

                    var users = await dbConnection.QueryAsync<User>(groupSql, new { UserID = userID });
                    var loc = users.FirstOrDefault();

                    
                    user.Longitude = loc?.Longitude;
                    user.Latitude = loc?.Latitude;
                    user.UserGroup = new Group { Name = user.GroupName };

                    resultData.Status = true;
                    resultData.Message = "Success";
                    resultData.Data = result.First();
                    return resultData;
                }
            }
            catch (Exception ex)
            {
                resultData.Status = false;
                resultData.Message = ex.Message;
                return resultData;
            }
        }

        public async Task<ResultData<User>> GetUserGroupDetails(int userID)
        {
            ResultData<User> resultData = new ResultData<User>();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                                        SELECT 
                                        gu.UserID,
                                        gu.Name,
                                        gu.Address,
                                        PassportNumber,
                                        gu.GroupID,
                                        g.Name AS GroupName
                                        FROM 
                                        GlobalUsers gu
                                        LEFT JOIN Groups g ON g.GroupID = gu.GroupID
                                        WHERE gu.UserID = @UserID;
                                  ";

                    var result = await dbConnection.QueryAsync<User>(sql, new { UserID = userID });
                    User user = result.First();

                    string groupSql = @"
                                        SELECT Latitude, Longitude, UserID FROM userlocations l 
                                        WHERE groupid=@GroupID AND
                                         l.AddedDate = 
                                         (SELECT max(AddedDate) FROM userlocations WHERE userid=l.UserID);
                                  ";

                    var users = await dbConnection.QueryAsync<User>(groupSql, new { GroupID = user.GroupID });

                    if (users!=null && users.Count() != 0)
                    {
                        var userGroup = users?.ToList()
                        .GroupBy(g => new { Latitude = g.Latitude, Longitude = g.Longitude })
                        .Select(x => new Group()
                        {
                            Latitude = x.FirstOrDefault().Latitude,
                            Longitude = x.FirstOrDefault().Longitude,
                            TotalCount = x.Count()
                        }).OrderByDescending(y => y.TotalCount).First();


                        userGroup.Name = user.GroupName;
                        user.UserGroup = userGroup;
                    }
                        


                    resultData.Status = true;
                    resultData.Message = "Success";
                    resultData.Data = result.First();
                    return resultData;
                }
            }
            catch (Exception ex)
            {
                resultData.Status = false;
                resultData.Message = ex.Message;
                return resultData;
            }
        }

        public async Task<ResultData> SaveUserLocation(UserLocationInsertModel userLocation)
        {
            ResultData resultData = new ResultData();

            try
            {
                using(IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                                        INSERT INTO 
                                          userlocations
                                            (
                                              userid,
                                              groupid,
                                              latitude, longitude
                                            )
                                            VALUES (
                                              @UserID,
                                              @GroupID,
                                              @Latitude, @Longitude
                                            );
                                  ";

                    var result = await dbConnection.ExecuteAsync(sql, userLocation);
                    if(result == 0)
                    {
                        resultData.Status = false;
                        resultData.Message = "Failed";
                        return resultData;
                    }

                    resultData.Status = true;
                    resultData.Message = "Success";
                    return resultData;
                }
            }
            catch(Exception ex)
            {
                resultData.Status = false;
                resultData.Message = ex.Message;
                return resultData;
            }
        }
    }
}
