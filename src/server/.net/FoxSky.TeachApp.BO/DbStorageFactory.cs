using FoxSky.TeachApp.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.BO
{
    public static class DbStorageFactory
    {
        public static DbStorageContext GetInstance()
        {
            var path = Path.Combine(Environment.CurrentDirectory, "db");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
                
            var ctx = new DbStorageContext(Path.Combine(path, "teachapp.sqlite"));

            if (!ctx.Database.CanConnect())
            {
                ctx.Database.EnsureCreated();

                LoadTestData(ctx);

            }

            return ctx;
        }

        private static void LoadTestData(DbStorageContext ctx)
        {
            var rnd = new Random();

            ctx.Add(new Category() { CategoryName = "None" });
            ctx.Add(new Category() { CategoryName = "Food" });
            ctx.Add(new Category() { CategoryName = "Cars" });
            ctx.Add(new Category() { CategoryName = "Animals" });
            ctx.Add(new Category() { CategoryName = "IT" });
            ctx.SaveChanges();

            for (int i = 0; i < 100; i++)
            {
                var words = new List<Word>();

                for (var j = 0; j < 100; j++)
                {
                    words.Add(new Word()
                    {
                        Phrase = StringUtilities.GetRndWord(13),
                        Note = StringUtilities.GetRndWord(20),
                        Translation = StringUtilities.GetRndWord(10),
                        CategoryId = rnd.Next(1, 5)
                    }) ;                
                }

                ctx.Users.Add(new User() { 
                    Surname = StringUtilities.GetRndWord(10),
                    Forename = StringUtilities.GetRndWord(10),
                    PasswordHash = User.GetPasswordHash("test"),
                    Email = StringUtilities.GetRndWord(10),
                    Login = StringUtilities.GetRndWord(10),
                    Words = words 
                });
                ctx.SaveChanges();
            }
        }
    }
}
