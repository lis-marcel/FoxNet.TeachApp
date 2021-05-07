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
        public void CheckAddUserTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GenerateRandomWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                var us = new UserService(db);

                us.AddUser(new Data.UserData() { Forename = "1", Surname = "1" });
                us.AddUser(new Data.UserData() { Forename = "2", Surname = "2" });

                var all = db.Users.ToList();
                Assert.AreEqual(2, all.Count);

                var u1 = db.Users.Where(u => u.Surname == "1" && u.Forename == "1").Single();
                Assert.AreEqual("1", u1.Surname);

                db.Database.EnsureDeleted();
            }
        }
    }
}
