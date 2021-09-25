using Microsoft.EntityFrameworkCore;
using PersonEditor.Model.Entities;
using System;
using System.IO;

namespace PersonEditor.Model.Context
{
    public class DataContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public string PathToDB { get; set; }

        public DataContext()
        {
            // DB liegt im %localappdata% Ordner
            var folder = Directory.GetParent(Environment.CurrentDirectory).FullName;
            PathToDB = $@"{folder}\Database\Person.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={PathToDB}");
    }
}
