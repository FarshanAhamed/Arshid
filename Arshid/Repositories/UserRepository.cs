using Arshid.Configuration;
using Arshid.Web.Constants;
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
                                        gu.PassportNumber, gu.Gender, gu.ContactNumber,
                                        gu.GroupID, gu.Age,
                                        g.Name AS GroupName, g.GroupContact, g.Country
                                        FROM 
                                        GlobalUsers gu
                                        LEFT JOIN Groups g ON g.GroupID = gu.GroupID
                                        WHERE gu.UserID = @UserID;
                                  ";

                    var result = await dbConnection.QueryAsync<User>(sql, new { UserID = userID });
                    User user = result.First();

                    string groupSql = @"
                                        SELECT Latitude, Longitude, AddedDate FROM userlocations
                                        WHERE userid=@UserID AND
                                         AddedDate = 
                                         (SELECT max(AddedDate) FROM userlocations WHERE userid=@UserID);
                                  ";

                    var users = await dbConnection.QueryAsync<User>(groupSql, new { UserID = userID });
                    var loc = users.FirstOrDefault();

                    
                    user.Longitude = loc?.Longitude;
                    user.Latitude = loc?.Latitude;
                    user.AddedDate = loc?.AddedDate;

                    // Get the current waypoint
                    var waypointList = WayPoints.GetWayPointList();
                    var waypointDict = WayPoints.GetWayPointDict();

                    string currentKey = user.Latitude + "" + user.Longitude;
                    var currLocation = waypointDict[currentKey];

                    user.UserGroup = new Group
                    {
                        GroupID = user.GroupID,
                        Name = user.GroupName,
                        GroupContact = user.GroupContact,
                        LocationName = currLocation?.Name,
                        Country = user.Country
                    };

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
                                        gu.PassportNumber, gu.Gender, gu.ContactNumber,
                                        gu.GroupID, gu.Age,
                                        g.Name AS GroupName, g.GroupContact, g.Country
                                        FROM 
                                        GlobalUsers gu
                                        LEFT JOIN Groups g ON g.GroupID = gu.GroupID
                                        WHERE gu.UserID = @UserID;
                                  ";

                    var result = await dbConnection.QueryAsync<User>(sql, new { UserID = userID });
                    User user = result.First();

                    string groupSql = @"
                                        SELECT Latitude, Longitude, Count(UserID) AS TotalCount, max(AddedDate) AS AddedDate
                                        FROM userlocations l 
                                        WHERE groupid=@GroupID AND
                                        l.AddedDate = 
                                        (SELECT max(AddedDate) FROM userlocations WHERE userid=l.UserID)
                                        GROUP BY Latitude,Longitude
                                        ORDER BY TotalCount DESC 
                                        LIMIT 1
                                  ";

                    var users = await dbConnection.QueryAsync<Group>(groupSql, new { GroupID = user.GroupID });

                    if (users != null && users.Count() != 0)
                    {
                        //var userGroup = users?.ToList()
                        //.GroupBy(g => new { Latitude = g.Latitude, Longitude = g.Longitude })
                        //.Select(x => new Group()
                        //{
                        //    Latitude = x.FirstOrDefault().Latitude,
                        //    Longitude = x.FirstOrDefault().Longitude,
                        //    TotalCount = x.Count()
                        //}).OrderByDescending(y => y.TotalCount).First();

                        var userGroup = users.First();

                        // Get the current waypoint
                        var waypointList = WayPoints.GetWayPointList();
                        var waypointDict = WayPoints.GetWayPointDict();

                        string currentKey = userGroup.Latitude + "" + userGroup.Longitude;
                        var currLocation = waypointDict[currentKey];

                        userGroup.GroupID = user.GroupID;
                        userGroup.Name = user.GroupName;
                        userGroup.GroupContact = user.GroupContact;
                        userGroup.LocationName = currLocation.Name;
                        userGroup.Country = user.Country;
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

        public async Task<ResultData<List<Group>>> GenerateHeatMap()
        {
            ResultData<List<Group>> resultData = new ResultData<List<Group>>();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    // Take latest location of all user
                    string sql = @"
                                    SELECT l.Latitude, l.Longitude, l.UserID, l.GroupID, g.Name 
                                    FROM userlocations l
                                    LEFT JOIN Groups g ON (g.GroupID = l.GroupID)
                                    WHERE l.AddedDate = 
                                        (SELECT max(AddedDate) FROM userlocations WHERE userid=l.UserID);
                                  ";
                    var userList = await dbConnection.QueryAsync<User>(sql);

                    // Group the users by their group id
                    var groupList = userList.GroupBy(g => g.GroupID)
                        .Select(x => new Group
                        {
                            Name = x.FirstOrDefault().Name,
                            GroupID = x.FirstOrDefault().GroupID,
                            UserCount = x.Count(),
                            LocatedGroup = x
                                .Select(y => new User
                                {
                                    UserID = y.UserID,
                                    Latitude = y.Latitude,
                                    Longitude = y.Longitude
                                })
                                .GroupBy(g2 => new { Latitude = g2.Latitude, Longitude = g2.Longitude })
                                .Select(j => new Group()
                                {
                                    Latitude = j.FirstOrDefault().Latitude,
                                    Longitude = j.FirstOrDefault().Longitude,
                                    TotalCount = j.Count()
                                }).OrderByDescending(k => k.TotalCount).First()
                        }).ToList();

                    foreach (var group in groupList)
                    {
                        group.Latitude = group.LocatedGroup.Latitude;
                        group.Longitude = group.LocatedGroup.Longitude;
                    }


                    resultData.Status = true;
                    resultData.Message = "Success";
                    resultData.Data = groupList;
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

        public async Task<ResultData<List<WayPoint>>> GenerateZonalHeatMap()
        {
            ResultData<List<WayPoint>> resultData = new ResultData<List<WayPoint>>();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    // Take latest location of all user
                    string sql = @"
                                    SELECT l.Latitude, l.Longitude, l.UserID, l.GroupID, g.Name 
                                    FROM userlocations l
                                    LEFT JOIN Groups g ON (g.GroupID = l.GroupID)
                                    WHERE l.AddedDate = 
                                        (SELECT max(AddedDate) FROM userlocations WHERE userid=l.UserID);
                                  ";
                    var userList = await dbConnection.QueryAsync<User>(sql);

                    // Get the current waypoint
                    var waypointList = WayPoints.GetWayPointList();
                    var waypointDict = WayPoints.GetWayPointDict();

                    // Group the users by their group id
                    var zoneList = userList.GroupBy(g => new { g.Latitude, g.Longitude })
                        .Select(x => new WayPoint
                        {
                            Name = waypointDict[x.FirstOrDefault().Latitude + "" + x.FirstOrDefault().Longitude].Name,
                            Latitude = x.FirstOrDefault().Latitude.GetValueOrDefault(),
                            Longitude = x.FirstOrDefault().Longitude.GetValueOrDefault(),
                            UserCount = x.Count()
                        }).ToList();


                    resultData.Status = true;
                    resultData.Message = "Success";
                    resultData.Data = zoneList;
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

        public async Task<ResultData<Stats>> GetStats()
        {
            ResultData<Stats> resultData = new ResultData<Stats>();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                                        SELECT *, 
	                                        (SELECT COUNT(DISTINCT UserID) FROM UserLocations) AS UserCount,
                                            (SELECT COUNT(DISTINCT GroupID) FROM UserLocations) AS GroupCount 
                                        FROM Groups
                                        FETCH FIRST 1 ROWS ONLY;
                                  ";

                    var result = await dbConnection.QueryAsync<Stats>(sql);

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

        public async Task<ResultData<List<Group>>> GetAllGroups()
        {
            ResultData<List<Group>> resultData = new ResultData<List<Group>>();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                                        SELECT * FROM Groups g
                                        LEFT JOIN GlobalUsers u ON (g.GroupID = u.GroupID);
                                  ";

                    var userList = await dbConnection.QueryAsync<User>(sql);

                    userList = userList.Skip(6);

                    var groupList = userList.GroupBy(g => g.GroupID)
                        .Select(x => new Group()
                        {
                            GroupID = x.FirstOrDefault().GroupID,
                            UserIDs = x.Select(y => y.UserID.GetValueOrDefault()).ToList()
                        }).ToList(); 

                    resultData.Status = true;
                    resultData.Message = "Success";
                    resultData.Data = groupList;
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

        public async Task<ResultData> DeleteAllUserLocations()
        {
            ResultData resultData = new ResultData();
            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                         DELETE FROM UserLocations;
                                  ";

                    var result = await dbConnection.ExecuteAsync(sql);

                    resultData.Status = true;
                    resultData.Message = "Success";
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

        public async Task<ResultData<IEnumerable<User>>> GetGroupUsers(int groupID)
        {
            ResultData<IEnumerable<User>> resultData = new ResultData<IEnumerable<User>>();
            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {
                    string sql = @"
                                        SELECT 
                                        gu.UserID,
                                        gu.Name, ul.Latitude, ul.Longitude, ul.AddedDate,
                                        gu.Address,
                                        gu.PassportNumber, gu.Gender, gu.ContactNumber,
                                        gu.GroupID, gu.Age                                        
                                        FROM 
                                        GlobalUsers gu
                                        LEFT JOIN userLocations ul ON ul.UserID = gu.UserID 
                                        AND ul.AddedDate = (SELECT max(AddedDate) FROM userlocations WHERE userid=gu.UserID)
                                        WHERE gu.GroupID = @GroupID
                                  ";

                    var result = await dbConnection.QueryAsync<User>(sql, new { GroupID = groupID });

                    resultData.Status = true;
                    resultData.Message = "Success";
                    resultData.Data = result;
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

        public async Task<ResultData> SaveMultipleUserLocations(
           List<UserLocation> userLocations)
        {
            ResultData resultData = new ResultData();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
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

                    var result = await dbConnection.ExecuteAsync(sql, userLocations);

                    resultData.Status = true;
                    resultData.Message = "Success";
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

        public async Task<ResultData> ResetDatabase(string newsql)
        {
            ResultData resultData = new ResultData();

            try
            {
                using (IDbConnection dbConnection = _connectionManager.getNew())
                {

                    var result = await dbConnection.ExecuteAsync(newsql);

                    if (result <= 0)
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
            catch (Exception ex)
            {
                resultData.Status = false;
                resultData.Message = ex.Message;
                return resultData;
            }
        }

    }
}
