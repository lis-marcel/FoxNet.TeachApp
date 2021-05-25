using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoxSky.TeachApp.BO;
using System;
using System.Text;
using FoxSky.TeachApp.Common;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO.Test
{
    [TestClass]
    public class CategoryTest
    {
        [TestMethod]
        public void CheckCategoryTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();
                try
                {
                    var category = new List<Category>();
                    db.Categories.Add(new Category { CategoryName = "house" });
                    db.Categories.Add(new Category { CategoryName = "programming" });
                    db.Categories.Add(new Category { CategoryName = "civ5" });

                    db.SaveChanges();

                    var exist = db.Categories.Find(3);

                    Assert.AreEqual("civ5", exist.CategoryName);
                }
                finally
                {
                    db.Database.EnsureDeleted();
                }
            }
        }
    }
}
