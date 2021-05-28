using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace FoxSky.TeachApp.Service
{
    public class UserService : ServiceBase
    {
        public UserService() : base()
        {
        }

        public UserService(DbStorageContext context) : base(context)
        {
        }

        public int AddUser(UserData userData)
        {
            var u = new User() {
                Login = userData.Login,
                Email = userData.Email,
                Forename = userData.Forename, 
                Surname = userData.Surname,
                PasswordHash = User.GetPasswordHash(userData.Password), 
            };

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
                UserData ud = Translate(u);
                res.Add(ud);
            }

            return res;
        }

        private static UserData Translate(User user)
        {
            return user != null ?
                new UserData() { UserId = user.UserId, Forename = user.Forename, Surname = user.Surname, Email = user.Email, Password = user.PasswordHash } :
                null;
        }

        public UserData GetUser(int userId)
        {
            var db = GetContext(); 
            var user = db.Users.SingleOrDefault(u => u.UserId == userId);

            return user != null ?
                Translate(user) :
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

        public UserData Login(string login, string password)
        {
            var hash = User.GetPasswordHash(password);
            var db = GetContext();

            var user = db.Users.Where(u =>
                u.Login == login &&
                u.PasswordHash == hash
             ).FirstOrDefault();

            return Translate(user);
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
