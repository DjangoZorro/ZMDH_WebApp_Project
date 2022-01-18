using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZMDH_WebApp.Hubs;
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
            builder.Entity<Condition>()
                .HasMany(x => x.Entries)
                .WithOne();
            builder.Entity<Condition>()
                .HasMany(x => x.Clienten)
                .WithOne();
            builder.Entity<Client>()
                .HasOne(x => x.Guardian)
                .WithMany();
            builder.Entity<Client>()
                .HasOne(x => x.Moderator)
                .WithMany();
            builder.Entity<Client>()
                .HasOne(x => x.Pedagoog)
                .WithMany();
            builder.Entity<ChatHub>()
                .HasOne(x => x.Pedagoog)
                .WithMany();
            builder.Entity<ChatHub>()
                .HasOne(x => x.Client)
                .WithMany();
            builder.Entity<Diploma>()
                .HasMany(x => x.Pedagogen)
                .WithOne();
            builder.Entity<Moderator>()
                .HasMany(x => x.Pedagogen)
                .WithOne();
            builder.Entity<SelfHelpGroup>()
                .HasMany(x => x.Clienten)
                .WithOne();
        }

        public DbSet<Client> Clienten { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Diploma> Diplomas { get; set; }
        public DbSet<Guardian> Guardians { get; set; }
        public DbSet<Pedagoog> Pedagogen { get; set; }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Moderator> Moderators { get; set; }
        public DbSet<SelfHelpGroup> SelfHelpGroups { get; set; }
    }
}
