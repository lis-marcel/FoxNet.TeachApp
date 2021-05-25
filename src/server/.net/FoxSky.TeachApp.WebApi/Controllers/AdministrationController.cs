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
            using (var service = new UserService())
            {
                return service.AddUser(userData); 
            }
        }

        [HttpGet]
        [Route("all")]
        public IList<UserData> GetUsers()
        {
            using (var service = new UserService())
            {
                return service.GetUsers();
            }
        }

        [HttpGet]
        [Route("get/{id}")]
        public UserData GetUser(int id)
        {
            using (var service = new UserService())
            {
                return service.GetUser(id);
            }
        }

        [HttpPost]
        [Route("edit")]
        public void EditUser(UserData userData)
        {
            using (var service = new UserService())
            {
                service.EditUser(userData);
            }
        }

        [HttpPost]
        [Route("delete/{id}")]
        public void DeleteUser(int id)
        {
            using (var service = new UserService())
            {
                service.DeleteUser(id);
            }
        }
    }
}
