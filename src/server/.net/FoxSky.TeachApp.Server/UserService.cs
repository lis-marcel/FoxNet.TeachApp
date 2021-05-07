using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;

namespace FoxSky.TeachApp.Service
{
    public class UserService
    {
        private DbStorageContext context;

        public UserService()
        {
        }

        public UserService(DbStorageContext context)
        {
            this.context = context;
        }

        private DbStorageContext GetContext()
        {
            if (context == null)
            {
                context = DbStorageFactory.GetInstance();
            }

            return context;
        }

        public int AddUser(UserData userData)
        {
            var u = new User() { Surname = userData.Surname, Forename = userData.Forename };
            var db = GetContext();
            var res = db.Users.Add(u);
            db.SaveChanges();

            return res.Entity.UserId;
        }
    }
}
