using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FoxSky.TeachApp.BO
{
    public class DbStorageContext : DbContext
    {
        public string DbPath { get; set; }

        public DbStorageContext(string dbPath) : base() => DbPath = dbPath;

        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data source={DbPath}");
    }
}
