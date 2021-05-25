using Microsoft.VisualStudio.TestTools.UnitTesting;
using FoxSky.TeachApp.BO;
using System;
using System.Text;
using FoxSky.TeachApp.Common;
using System.Collections.Generic;

namespace FoxSky.TeachApp.BO.Test
{
    [TestClass]
    public class TagLinkTest
    {
        public void CheckTagLinkTest()
        {
            using (var db = new DbStorageContext($"{StringUtilities.GetRndWord(10)}.sqlite"))
            {
                db.Database.EnsureCreated();

                try
                {
                    var tagLink = new List<TagLink>();

                    //db.Tags.Add(new TagLink { TagId = 1, WordId = 1 });
                }
                finally
                {
                    db.Database.EnsureDeleted();
                }
            }
        }
    }
}
