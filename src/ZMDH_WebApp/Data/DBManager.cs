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

        public DbSet<Praktijk> Praktijken { get; set; }
    }
}
