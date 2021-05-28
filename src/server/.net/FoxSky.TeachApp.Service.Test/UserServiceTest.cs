using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text;
using System.Collections.Generic;
using FoxSky.TeachApp.Service;
using System.Linq;
using FoxSky.TeachApp.BO;
using FoxSky.TeachApp.Common;

namespace FoxSky.TeachApp.Service.Test
{
    [TestClass]
    public class UserServiceTest
    {
        [TestMethod]
        public void AddUserTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                // Add users using the service
                us.AddUser(new Data.UserData() { Forename = "1", Surname = "1" });
                us.AddUser(new Data.UserData() { Forename = "2", Surname = "2" });

                // Test if added using the BOs
                var all = db.Users.ToList();
                Assert.AreEqual(2, all.Count);

                var u1 = db.Users.Where(u => u.Surname == "1" && u.Forename == "1").Single();
                Assert.AreEqual("1", u1.Surname);

                db.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void GetUsersTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                // Add users using the service
                var id1 = us.AddUser(new Data.UserData() { Forename = "Syty", Surname = "Kokos" });
                var id2 = us.AddUser(new Data.UserData() { Forename = "G³odny", Surname = "Felek" });

                var users = us.GetUsers();
                Assert.AreEqual(2, users.Count);
                Assert.AreEqual(id1, users.FirstOrDefault(u => u.Surname == "Kokos").UserId);
                Assert.AreEqual(id2, users.FirstOrDefault(u => u.Forename == "G³odny").UserId);

                db.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void GetUserTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                // Add users using the service
                var id = us.AddUser(new Data.UserData() { Forename = "Juna", Surname = "Juñska" });

                var user = us.GetUser(id);
                Assert.AreEqual(id, user.UserId);
                //Assert.AreEqual("Juna", users.Forename);
                Assert.AreSame("Juna", user.Forename);

                db.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void EditUsersTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                // Add users using the service
                var id1 = us.AddUser(new Data.UserData() { Forename = "Patyczek", Surname = "Kokosek" });
                var id2 = us.AddUser(new Data.UserData() { Forename = "Pulchniutki", Surname = "Feleuœ" });

                var u2 = us.GetUser(id2);
                Assert.AreEqual(id2, u2.UserId);

                u2.Surname = "Kleofas";
                us.EditUser(u2);

                var u2_2 = us.GetUser(id2);
                Assert.AreEqual(id2, u2.UserId);
                Assert.AreEqual("Kleofas", u2_2.Surname);
            }
        }

        [TestMethod]
        public void DeleteUsersTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                // Add users using the service
                var id1 = us.AddUser(new Data.UserData() { Forename = "Marcel", Surname = "Lis" });
                var id2 = us.AddUser(new Data.UserData() { Forename = "Kicia", Surname = "Micia" });

                var users = us.GetUsers();
                Assert.AreEqual(2, users.Count);

                us.DeleteUser(id1);

                users = us.GetUsers();
                Assert.AreEqual(1, users.Count);
                Assert.AreEqual(id2, users.FirstOrDefault().UserId);

                db.Database.EnsureDeleted();
            }
        }

        [TestMethod]
        public void LoginTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                // Add users using the service
                var id1 = us.AddUser(new Data.UserData() { Forename = "Marcel", Surname = "Lis", Login = "ok1", Password = "test" });
                var id2 = us.AddUser(new Data.UserData() { Forename = "Marcel", Surname = "Lis", Login = "ok2", Password = "test" });
                Assert.IsTrue(id1 != id2);

                var loggedId1 = us.Login("ok1", "test");
                Assert.IsNotNull(loggedId1);
                Assert.AreEqual(id1, loggedId1.UserId);

                var loggedId2 = us.Login("ok2", "test");
                Assert.IsNotNull(loggedId2);
                Assert.AreEqual(id2, loggedId2.UserId);

                var notLoggedWrongPwd = us.Login("ok1", "duppa");
                Assert.IsNull(notLoggedWrongPwd);

                var notLoggedWrongLogin = us.Login("ok1_", "dupa");
                Assert.IsNull(notLoggedWrongLogin);
            }
        }
    }
}
