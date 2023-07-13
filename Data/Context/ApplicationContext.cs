using Data.Entities.Concrete;
using Data.Entities.SeedData;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class ApplicationContext:IdentityDbContext<AppUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().Property(x=>x.UnitPrice).HasColumnType("decimal").HasPrecision(8,2);

            builder.ApplyConfiguration(new CategorySeedData());
            builder.ApplyConfiguration(new ProductSeedData());

            /////////////admin giriş//////////////////////////////////////
            string adminId = "02174cf0–9412–4cfe-afbf-59f706d72cf6";
            string roleId = "341743f0-asd2–42de-afbf-59kmkkmk72cf6";

            builder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = roleId
            });
            var hasher = new PasswordHasher<IdentityUser>();

            var appUser = new AppUser
            {
                Id = adminId,
                UserName = "Admin",
                Email = "admin@toyssales.com",
                EmailConfirmed = false,
                NormalizedUserName = "ADMIN"
            };

            PasswordHasher<AppUser> passwordHas = new PasswordHasher<AppUser>();
            appUser.PasswordHash = passwordHas.HashPassword(appUser, "123");
            builder.Entity<AppUser>().HasData(appUser);

            builder.Entity<IdentityUserRole<string>>().HasData
                (new IdentityUserRole<string>
                {
                    RoleId = roleId,
                    UserId = adminId
                });
            ///////////////////////////////////////////////////////////////

            base.OnModelCreating(builder);
        }
    }
}
