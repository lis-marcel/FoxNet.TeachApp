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
    public class UserController : ControllerBase
    {
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

        [HttpPost]
        [Route("edit")]
        public void EditUser(UserData userData)
        {
            new UserService().EditUser(userData);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteUser(int id)
        {
            new UserService().DeleteUser(id);
        }
    }
}
