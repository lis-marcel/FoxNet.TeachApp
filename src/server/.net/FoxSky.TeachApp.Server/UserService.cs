using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
            var u = new User() { Forename = userData.Forename, Surname = userData.Surname, PasswordHash = User.GetPasswordHash(userData.Password), Email = userData.Email };
            var db = GetContext();
            var res = db.Users.Add(u);
            db.SaveChanges();

            return res.Entity.UserId;

        }

        public IList<UserData> GetUsers()
        {
            var db = GetContext();
            var res = new List<UserData>();

            foreach (var u in db.Users)
            {
                var ud = new UserData() { Forename = u.Forename, Surname = u.Surname, UserId = u.UserId };
                res.Add(ud);
            }

            return res;
        }

        public UserData GetUser(int userId)
        {
            var db = GetContext(); 
            var user = db.Users.SingleOrDefault(u => u.UserId == userId);

            return user != null ?
                new UserData() { UserId = user.UserId, Forename = user.Forename, Surname = user.Surname } :
                null;
        }

        public void EditUser(UserData userData)
        {
            var db = GetContext();
            var user = db.Users.SingleOrDefault(d => d.UserId == userData.UserId);

            if (user == null)
            {
                db.SaveChanges();
            }

            else
            {
                user.Surname = userData.Surname;
                user.Forename = userData.Forename;
                db.SaveChanges();
            }
        }

        public void DeleteUser(int userId)
        {
            var db = GetContext();
            var res = db.Users.Single(d => d.UserId == userId);
            db.Users.Remove(res);

            db.SaveChanges();
        }
    }
}
