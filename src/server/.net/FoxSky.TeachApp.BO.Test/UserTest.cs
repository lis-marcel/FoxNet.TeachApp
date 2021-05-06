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
            using (var db = new DbStorageContext($"{StringUtilities.GenerateRandomWord(10)}.sqlite"))
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

        [TestMethod]
        public void CheckWordsTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GenerateRandomWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                try
                {
                    var words = new List<Word>();
                    words.Add(new Word { Phrase = "kitty", Translation = "kotek" });
                    words.Add(new Word { Phrase = "kitty1", Translation = "kicia" });
                    words.Add(new Word { Phrase = "kitty2", Translation = "micia" });
                    words.Add(new Word { Phrase = "kitty3", Translation = "felek" });
                    db.Users.Add(new User { Forename = "marcel", Surname = "fox", Word = words });
                    db.SaveChanges();

                    var existing = db.Users.Find(1);
                    Assert.IsNotNull(existing);

                    Assert.AreEqual(words.Count, existing.Word.Count);
                }
                finally
                {
                    db.Database.EnsureDeleted();
                }
            }
        }
    }
}
