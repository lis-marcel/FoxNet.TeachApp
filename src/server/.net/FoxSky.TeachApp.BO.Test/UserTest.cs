using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoxSky.TeachApp.BO;
using System;
using System.Text;
using FoxSky.TeachApp.Common;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO.Test
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void CheckAddingUserTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                try
                {
                    db.Users.Add(new User() { Forename = "marcel", Surname = "fox" });
                    db.SaveChanges();

                    var existing = db.Users.Find(1);
                    Assert.IsNotNull(existing);
                    Assert.AreEqual("marcel", existing.Forename);

                    var missing = db.Users.Find(2);
                    Assert.IsNull(missing);
                }
                finally
                {
                    db.Database.EnsureDeleted();
                }
            }
        }
    }    
}
