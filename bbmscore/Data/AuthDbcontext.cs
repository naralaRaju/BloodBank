using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.WebSockets;

namespace bbmscore.Data
{
    public class AuthDbcontext : IdentityDbContext
    {
        public AuthDbcontext(DbContextOptions<AuthDbcontext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var UserRoleId = "a4e80ba7-cfde-4767-89d0-993a833acf5f";
            var AdminRoleId = "09b9bf41-6be4-413f-871a-747a1752e166";
            var SuperadminRoleId = "83ba0756-db54-4703-b487-d5cf91c019cb";

            //assigning roles user,admin,superadmin
            var roles = new List<IdentityRole>()
            {
                new IdentityRole
                {
                    Id = UserRoleId,
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp=UserRoleId,
                },
                new IdentityRole
                {
                    Id = AdminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp=AdminRoleId,
                },
                new IdentityRole
                {
                    Id = SuperadminRoleId,
                    Name = "Superadmin",
                    NormalizedName = "SUPERADMIN",
                    ConcurrencyStamp=SuperadminRoleId,
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);
            //seeding superadminuser 
            var superaminuserid = "3c1d563a-ee7c-438f-a540-5d7fe8168c33";
            var superadminuser = new IdentityUser
            {
                Id = superaminuserid,
                UserName = "superadmin",
                NormalizedUserName = "SUPERADMIN",
                Email = "superadmin@gmail.com",
                ConcurrencyStamp = "SUPERADMIN@GMAIL.COM",
                PhoneNumber="7601067244"
            };
            superadminuser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(superadminuser, "superadmin@123");
            builder.Entity<IdentityUser>().HasData(superadminuser);
            //assigning all roles to superadmin
            var SuperAdminUser = new List<IdentityUserRole<string>>
            {
                new IdentityUserRole<string>
                {
                     RoleId=UserRoleId,
                     UserId=superaminuserid,
                },
                new IdentityUserRole<string>
                {
                    RoleId=AdminRoleId,
                    UserId=superaminuserid,

                },  
                new IdentityUserRole<string>
                {
                    RoleId=SuperadminRoleId,
                    UserId=superaminuserid,
                }
            };
            builder.Entity<IdentityUserRole<string>>().HasData(SuperAdminUser);
            var admin1 = "79804520-6822-4ff6-aa99-17de99098494";
            var identityuser = new IdentityUser
            {
                UserName = "Sowmya",
                Email = "sowmya@gmail.com",
                PhoneNumber = "9347096598",
                Id=admin1

            };
            identityuser.PasswordHash = new PasswordHasher<IdentityUser>().HashPassword(identityuser, "Sowmya@123");
            builder.Entity<IdentityUser>().HasData(identityuser);
            var AdminUser1 = new List<IdentityUserRole<string>>
            {
                
                new IdentityUserRole<string>
                {
                    RoleId=AdminRoleId,
                    UserId=admin1,

                }
               
            };
            builder.Entity<IdentityUserRole<string>>().HasData(AdminUser1);
        }
       
    }
}
