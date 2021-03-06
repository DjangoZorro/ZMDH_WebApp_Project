using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Models;

namespace ZMDH_WebApp.Data
{
    public class DBManager : IdentityDbContext
    {
        public DBManager (DbContextOptions<DBManager> options)
            : base(options)
        {
        }

        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Student", NormalizedName = "STUDENT", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        //     builder.Entity<IdentityRole>().HasData(new IdentityRole { Name = "Docent", NormalizedName = "DOCENT", Id = Guid.NewGuid().ToString(), ConcurrencyStamp = Guid.NewGuid().ToString() });
        //     base.OnModelCreating(builder);
        // }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Client> Clienten { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Pedagoog> Pedagogen { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<SelfHelpGroup> SelfHelpGroups { get; set; }
        public DbSet<Therapy> Therapies { get; set; }
    }
}
