using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arshid.Configuration;
using Arshid.Web.Constants;
using Arshid.Web.Interfaces;
using Arshid.Web.Models;
using Arshid.Web.Models.InsertModels;
using Microsoft.AspNetCore.Mvc;

namespace Arshid.Controllers
{
    [Route("v1/[controller]")]
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpPost("SaveUserLocation")]
        public async Task<IActionResult> SaveUserLocation([FromBody]UserLocationInsertModel userLocation)
        {
            try
            {
                var result = await _userService.SaveUserLocation(userLocation);

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUA300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUA100", result.Message, result.Data);
                return new ObjectResult(success);
            }
            catch(Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUA300", ex.Message, null);
                return new ObjectResult(response);
            }
        }


        [HttpGet("GetUserLocation/{userId}")]
        public async Task<IActionResult> GetUserLocation(int? userId)
        {
            try
            {
                var result = await _userService.GetUserLocation(userId.GetValueOrDefault());

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUB300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUB100", result.Message, result.Data);
                return new ObjectResult(success);
            }
            catch (Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUB300", ex.Message, null);
                return new ObjectResult(response);
            }
        }


        [HttpGet("GetGroupLocation/{userId}")]
        public async Task<IActionResult> GetGroupLocation(int? userId)
        {
            try
            {
                var result = await _userService.GetGroupLocation(userId.GetValueOrDefault());

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUC300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUC100", result.Message, result.Data);
                return new ObjectResult(success);
            }
            catch (Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUC300", ex.Message, null);
                return new ObjectResult(response);
            }
        }

        [HttpGet("GenerateHeatmap")]
        public async Task<IActionResult> GenerateHeatmap()
        {
            try
            {
                var result = await _userService.GenerateHeatmap();

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUD300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUD100", result.Message, result.Data);
                return new ObjectResult(success);
            }
            catch (Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUD300", ex.Message, null);
                return new ObjectResult(response);
            }
        }

        [HttpGet("GetStats")]
        public async Task<IActionResult> GetStats()
        {
            try
            {
                var result = await _userService.GetStats();

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUE300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUE100", result.Message, result.Data);
                return new ObjectResult(success);
            }
            catch (Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUE300", ex.Message, null);
                return new ObjectResult(response);
            }
        }

        [HttpPost("GenerateUserLocations")]
        public async Task<IActionResult> GenerateUserLocations()
        {
            try
            {
                var result = await _userService.GenerateUserLocations();

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUE300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUE100", result.Message, true);
                return new ObjectResult(success);
            }
            catch (Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUE300", ex.Message, null);
                return new ObjectResult(response);
            }
        }


        [HttpGet("GetGroupUsers/{groupId}")]
        public async Task<IActionResult> GetGroupUsers(int? groupId)
        {
            try
            {
                var result = await _userService.GetGroupUsers(groupId.GetValueOrDefault());

                if (!result.Status)
                {
                    var errorResponse = ArshidResponse<Object>.SetResponse("AUF300", result.Message, null);
                    return new ObjectResult(errorResponse);
                }

                var success = ArshidResponse<Object>.SetResponse("AUF100", result.Message, result.Data);
                return new ObjectResult(success);
            }
            catch (Exception ex)
            {
                var response = ArshidResponse<Object>.SetResponse("AUF300", ex.Message, null);
                return new ObjectResult(response);
            }
        }
    }
}
