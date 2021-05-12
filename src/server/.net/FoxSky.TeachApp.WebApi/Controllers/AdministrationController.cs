using FoxSky.TeachApp.Service;
using FoxSky.TeachApp.Service.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.WebApi.Controllers
{
    [ApiController]
    [Route("webapi/administration")]
    public class AdministrationController : ControllerBase
    {
        [HttpGet]
        [Route("addtestuser")]
        public int PutUsers()
        {
            return new UserService().AddUser(new UserData { Forename = "linux", Surname = "debian"});
        }

        [HttpPost]
        [Route("adduser")]
        public int AddUser([FromForm] UserData userData)
        {
            return new UserService().AddUser(userData);
        }

        [HttpGet]
        [Route("users")]
        public IList<UserData> GetUsers()
        {
            return new UserService().GetUsers();
        }

        [HttpPost]
        [Route("deleteuser/{id}")]
        public void DeleteUser(int id)
        {
            new UserService().DeleteUser(id);
        }
    }
}
