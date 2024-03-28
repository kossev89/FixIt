using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FixIt.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedAdmin(this IApplicationBuilder app) 
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Administrator"))
                    {
                        return;
                    }
                    var role = new IdentityRole { Name = "Administrator" };
                    await roleManager.CreateAsync(role);

                    var admin = await userManager.FindByEmailAsync("admin@mail.com");
                    await userManager.AddToRoleAsync(admin, "Administrator");
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
