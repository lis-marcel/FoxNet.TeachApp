using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoxSky.TeachApp.BO;
using System;
using System.Text;
using FoxSky.TeachApp.Common;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO.Test
{
    [TestClass]
    public class WordsTest
    {
        [TestMethod]
        public void CheckWordsTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                try
                {
                    var words = new List<Word>();
                    words.Add(new Word { Phrase = "kitty", Translation = "kotek" });
                    words.Add(new Word { Phrase = "kokosek", Translation = "nosek" });
                    words.Add(new Word { Phrase = "felek", Translation = "babeczka" });
                    db.Users.Add(new User { Forename = "marcel", Surname = "fox", PasswordHash = "marcel", Email = "marcel@mail.com", Words = words });
                    db.SaveChanges();

                    var existing = db.Users.Find(1);
                    Assert.IsNotNull(existing);

                    Assert.AreEqual(words.Count, existing.Words.Count);
                }
                finally
                {
                    db.Database.EnsureDeleted();
                }
            }
        }
    }
}
