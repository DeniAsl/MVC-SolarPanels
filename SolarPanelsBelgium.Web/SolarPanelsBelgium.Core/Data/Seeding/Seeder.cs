using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SolarPanelsBelgium.Core.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarPanelsBelgium.Core.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder builder)
        {
            const string AdminRoleId = "00000000-0000-0000-0000-000000000001";
            const string AdminRoleName = "Admin";

            const string AdminUserId = "00000000-0000-0000-0000-000000000001";
            const string AdminUserName = "admin";

            const string AdminEmail = "admin@pri.be";
            const string AdminFirstname = "Peter";
            const string AdminLastname = "Jansens";

            const string AdminUserPassword = "Test123?";

            const string CustomerRoleId = "00000000-0000-0000-0000-000000000002";
            const string CustomerRoleName = "Customer";

            const string CustomerUserId = "00000000-0000-0000-0000-000000000002";
            const string CustomerUserName = "customer";

            const string CustomerEmail = "customer@pri.be";
            const string CustomerFirstname = "Bart";
            const string CustomerLastname = "Delange";

            const string CustomerUserPassword = "Test123?";

            var adminApplicationUser = new ApplicationUser
            {
                Id = AdminUserId,
                UserName = AdminUserName,
                NormalizedUserName = AdminUserName.ToUpper(),
                Email = AdminEmail,
                NormalizedEmail = AdminEmail.ToUpper(),
                FirstName = AdminFirstname,
                LastName = AdminLastname,
                Address = "Dezeweg 12, Oostende 8400",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "VVPCRDAS3MJWQD5CSW2GWPRADBXEZINA",
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            };
            var customerApplicationUser = new ApplicationUser
            {
                Id = CustomerUserId,
                UserName = CustomerUserName,
                NormalizedUserName = CustomerUserName.ToUpper(),
                Email = CustomerEmail,
                NormalizedEmail = CustomerEmail.ToUpper(),
                FirstName = CustomerFirstname,
                LastName = CustomerLastname,
                Address = "Nieuwpad 120, Oostende 8400",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                SecurityStamp = "XCQCRDAS3MJWQV9VSW2GWSDADBXERUUN",
                ConcurrencyStamp = "d9564266-v905-9453-9aev-a9595053fc58"
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var adminHash = passwordHasher.HashPassword(adminApplicationUser, AdminUserPassword);
            var customerHash = passwordHasher.HashPassword(customerApplicationUser, CustomerUserPassword);
            adminApplicationUser.PasswordHash = adminHash;
            customerApplicationUser.PasswordHash = customerHash;

            builder.Entity<IdentityRole>().HasData(
                new IdentityRole {Id = AdminRoleId, Name = AdminRoleName, NormalizedName = AdminRoleName.ToUpper() },
                new IdentityRole { Id = CustomerRoleId, Name = CustomerRoleName, NormalizedName = CustomerRoleName.ToUpper() }
            );

            builder.Entity<ApplicationUser>().HasData(adminApplicationUser, customerApplicationUser);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> { RoleId = AdminRoleId, UserId = AdminUserId },
                new IdentityUserRole<string> { RoleId = CustomerRoleId, UserId = CustomerUserId }
            );
        }
    }
}
