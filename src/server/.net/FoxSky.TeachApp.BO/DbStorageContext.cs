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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Token> Tokens { get; set; }

        //public DbSet<Tag> Tags { get; set; }
        //public DbSet<TagLink> TagLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlite($"Data source={DbPath}");
    }
}
