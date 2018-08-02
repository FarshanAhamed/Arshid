using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Arshid.Configuration;
using Arshid.Web.Interfaces;
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

    }
}
