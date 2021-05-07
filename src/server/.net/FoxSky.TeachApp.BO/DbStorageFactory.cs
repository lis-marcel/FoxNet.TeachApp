using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.BO
{
    public static class DbStorageFactory
    {
        private static DbStorageContext dbStorageContext;

        public static DbStorageContext GetInstance()
        {
            if (dbStorageContext == null)
            {
                dbStorageContext = new DbStorageContext($"teachapp.sqlite");
                dbStorageContext.Database.EnsureCreated();
            }

            return dbStorageContext;
        }
    }
}
