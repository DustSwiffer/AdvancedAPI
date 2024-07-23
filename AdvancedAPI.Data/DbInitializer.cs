using AdvancedAPI.Data.Models;
using Microsoft.AspNetCore.Identity;

namespace AdvancedAPI.Data
{
    /// <summary>
    /// Database initializer.
    /// </summary>
    public class DbInitializer
    {
        /// <summary>
        /// Initialization of the database.
        /// </summary>
        public static async Task Initialize(IServiceProvider serviceProvider)
        {
            UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>();
            RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            // Seed roles
            await SeedRoles(roleManager);

            // Seed users
            await SeedAdminUser(userManager);
            await SeedUserUser(userManager);
        }

        /// <summary>
        /// Seeding roles into the database.
        /// </summary>
        private static async Task SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin", "User" };

            foreach (string roleName in roleNames)
            {
                bool roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    // Create the roles and seed them to the database
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
        }

        /// <summary>
        /// Seeding admin user into the database.
        /// </summary>
        private static async Task SeedAdminUser(UserManager<User> userManager)
        {
            User? adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new User
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
                    DateOfBirth = new DateTime(1980, 1, 1),
                    DisplayName = "Admin User",
                    GenderId = 1 // Assuming 1 is the ID for Male
                };

                IdentityResult? result = await userManager.CreateAsync(adminUser, "P@ssw0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }

        /// <summary>
        /// Seeding user user into the database.
        /// </summary>
        private static async Task SeedUserUser(UserManager<User> userManager)
        {
            User? userUser = await userManager.FindByEmailAsync("user@example.com");
            if (userUser == null)
            {
                userUser = new User
                {
                    UserName = "user@example.com",
                    Email = "user@example.com",
                    DateOfBirth = new DateTime(1990, 1, 1),
                    DisplayName = "Regular User",
                    GenderId = 2 // Assuming 2 is the ID for Female
                };

                IdentityResult? result = await userManager.CreateAsync(userUser, "P@ssw0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(userUser, "User");
                }
            }
        }
    }
}
