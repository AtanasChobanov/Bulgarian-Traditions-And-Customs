using BulgarianTraditionsAndCustoms.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace BulgarianTraditionsAndCustoms.Data
{
    public class DbSeeder
    {
        public static async Task SeedAllAsync(IServiceProvider service)
        {
            await SeedRolesAndAdminAsync(service);
        }

        private static async Task SeedRolesAndAdminAsync(IServiceProvider service)
        {
            var userManager = service.GetRequiredService<UserManager<ApplicationUser>>();
            var roleManager = service.GetRequiredService<RoleManager<IdentityRole>>();

            // Create Admin role if it doesn't exist
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            // Create Admin user if it doesn't exist
            var adminEmail = "admin@diploma.bg";

            var admin = await userManager.FindByEmailAsync(adminEmail);
            if (admin == null)
            {
                admin = new ApplicationUser
                {
                    UserName = adminEmail,
                    FirstName = "Atanas",
                    LastName = "Chobanov",
                    Email = adminEmail,
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true,
                };

                await userManager.CreateAsync(admin, "Admin@123");
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}
