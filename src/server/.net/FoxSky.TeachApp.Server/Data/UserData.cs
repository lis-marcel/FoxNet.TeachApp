using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoxSky.TeachApp.BO;

namespace FoxSky.TeachApp.Service.Data
{
    public class UserData
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
