using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyTwitter.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyTwitter.Data
{
    public class MyTwitterDbContext : IdentityDbContext<AppUser>
    {
        public MyTwitterDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<TwitterUser> Twitters { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserTwitterUser>()
                .HasKey(x => new { x.AppUserId, x.TwitterUserId });

            builder.Entity<AppUserTwitterUser>()
                .HasOne(u => u.AppUser)
                .WithMany(t => t.TwitterUsers)
                .HasForeignKey(u => u.AppUserId);

            builder.Entity<AppUserTwitterUser>()
                .HasOne(t => t.TwitterUser)
                .WithMany(u => u.AppUsers)
                .HasForeignKey(t => t.TwitterUserId);

            base.OnModelCreating(builder);
        }
    }
}