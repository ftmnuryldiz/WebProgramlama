using System;
using System.Collections.Generic;
using System.Text;
using WebOdevim.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace WebOdevim.Data
{
    public class ApplicationDbContext : IdentityDbContext<UserDetails>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories{ get; set; }
        
   
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            const string ADMIN_ID = "";

            const string ROLE_ID = "1";
            const string ROLE_ID2 = "2";

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = ROLE_ID2,
                    Name = "Uye",
                    NormalizedName = "UYE"
                }
            );

            var hasher = new PasswordHasher<UserDetails>();
            builder.Entity<UserDetails>().HasData(
                new UserDetails
                {
                    Id = ADMIN_ID,
                    UserName = "g201210370@sakarya.edu.tr",
                    NormalizedUserName = "G201210370@SAKARYA.EDU.TR",
                    Email = "g201210370@sakarya.edu.tr",
                    NormalizedEmail = "g201210370@SAKARYA.EDU.TR",
                    EmailConfirmed = true,
                    PasswordHash = hasher.HashPassword(null, "123"),
                    SecurityStamp = string.Empty
                }
            );

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ROLE_ID,
                    UserId = ADMIN_ID
                }
               
               
                );
        }
    }
}