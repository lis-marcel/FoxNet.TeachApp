using FoxSky.TeachApp.BO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoxSky.TeachApp.Service
{
    public class ServiceBase : IDisposable
    {
        private DbStorageContext context;
        private bool ownContext;

        public ServiceBase()
        {
        }

        public ServiceBase(DbStorageContext context)
        {
            this.context = context;
        }

        public DbStorageContext GetContext()
        {
            if (context == null)
            {
                context = DbStorageFactory.GetInstance();
                ownContext = true;
            }

            return context;
        }

        public void Dispose()
        {
            if (ownContext && context != null)
            {
                context.Dispose();
                context = null;
                ownContext = false;
            }
        }

    }
}
