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
            UserManager<IdentityUser> userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
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
        private static async Task SeedAdminUser(UserManager<IdentityUser> userManager)
        {
            IdentityUser? adminUser = await userManager.FindByEmailAsync("admin@example.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com",
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
        private static async Task SeedUserUser(UserManager<IdentityUser> userManager)
        {
            IdentityUser? adminUser = await userManager.FindByEmailAsync("user@example.com");
            if (adminUser == null)
            {
                adminUser = new IdentityUser
                {
                    UserName = "user@example.com",
                    Email = "user@example.com",
                };

                IdentityResult? result = await userManager.CreateAsync(adminUser, "P@ssw0rd");
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "User");
                }
            }
        }
    }
}
