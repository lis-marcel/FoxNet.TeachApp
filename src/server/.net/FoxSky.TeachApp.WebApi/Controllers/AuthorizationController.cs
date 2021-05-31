using FoxSky.TeachApp.Service;
using FoxSky.TeachApp.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.WebApi.Controllers
{
    [ApiController]
    [Route("webapi/authorization")]
    public class AuthorizationController : ControllerBase
    {
        [HttpPost]
        [Route("login")]
        public object LoginUser(UserData userData)
        {
            using (var userService = new UserService())
            {
                var loggedUser = userService.Login(userData.Login, userData.Password);

                if (loggedUser != null)
                    return Ok(new { 
                        Token = Guid.NewGuid().ToString(),
                        User = loggedUser
                    });
                else
                    return Unauthorized();
            }
        }
    }
}
