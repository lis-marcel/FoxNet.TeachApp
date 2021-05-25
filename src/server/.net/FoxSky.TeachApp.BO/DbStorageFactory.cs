using FoxSky.TeachApp.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.BO
{
    public static class DbStorageFactory
    {
        public static DbStorageContext GetInstance()
        {
            var ctx = new DbStorageContext($"teachapp.sqlite");

            if (!ctx.Database.CanConnect())
            {
                ctx.Database.EnsureCreated();

                LoadTestData(ctx);

            }

            return ctx;
        }

        private static void LoadTestData(DbStorageContext ctx)
        {
            var cTest = ctx.Categories.Add(new Category() { CategoryName = "TestData" });

            for (int i = 0; i < 100; i++)
            {
                var words = new List<Word>();

                for (var j = 0; j < 100; j++)
                {
                    words.Add(new Word() 
                    { 
                        Phrase = StringUtilities.GetRndWord(13), 
                        Note = StringUtilities.GetRndWord(20) 
                    });                
                }

                ctx.Users.Add(new User() { Surname = StringUtilities.GetRndWord(10), Words = words });
                ctx.SaveChanges();
            }

        }
    }
}
