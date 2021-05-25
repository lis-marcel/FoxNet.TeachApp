using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoxSky.TeachApp.BO;
using System;
using System.Text;
using FoxSky.TeachApp.Common;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO.Test
{
    [TestClass]
    public class TagTest
    {
        [TestMethod]
        public void CheckTagTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                try
                {
                    throw new NotImplementedException();
                    var tag = new List<Tag>();

                    //db.Tags.Add(new Tag { TagName = "school" });
                    //db.Tags.Add(new Tag { TagName = "work" });
                    //db.Tags.Add(new Tag { TagName = "eng" });

                    //db.SaveChanges();
                    
                    //var exist = db.Tags.Find(2);

                    //Assert.AreEqual("work", exist.TagName);
                }
                finally
                {
                    db.Database.EnsureDeleted();
                }
            }
        }
    }
}
