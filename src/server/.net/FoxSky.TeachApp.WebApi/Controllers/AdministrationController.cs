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
    [Route("webapi/administration/user")]
    public class AdministrationController : ControllerBase
    {
        /*[HttpGet]
        [Route("addtestuser")]
        public int PutUsers()
        {
            return new UserService().AddUser(new UserData { Forename = "linux", Surname = "debian"});
        }*/

        [HttpPost]
        [Route("add")]
        public int AddUser([FromBody] UserData userData)
        {
            return new UserService().AddUser(userData);
        }

        [HttpGet]
        [Route("all")]
        public IList<UserData> GetUsers()
        {
            return new UserService().GetUsers();
        }

        [HttpGet]
        [Route("get/{id}")]
        public UserData GetUser(int id)
        {
            return new UserService().GetUser(id);
        }

        [HttpGet]
        [Route("edit/{id}")]
        public void EditUser(int id)
        {
            new UserService().DeleteUser(id);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteUser(int id)
        {
            new UserService().DeleteUser(id);
        }
    }
}
