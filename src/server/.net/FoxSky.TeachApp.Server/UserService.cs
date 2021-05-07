using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;

namespace FoxSky.TeachApp.Service
{
    public class UserService
    {
        public int AddUser(UserData userData)
        {
            var u = new User() { Surname = userData.Surname, Forename = userData.Forename };
            var db = DbStorageFactory.GetInstance();
            var res = db.Users.Add(u);
            db.SaveChanges();

            return res.Entity.UserId;
        }
    }
}
