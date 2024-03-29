using FixIt.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace FixIt.Extensions
{
    public static class ApplicationBuilderExtension
    {
        public static IApplicationBuilder SeedRoles(this IApplicationBuilder app) 
        {
            using var scopedServices = app.ApplicationServices.CreateScope();
            var services = scopedServices.ServiceProvider;

            var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

            Task
                .Run(async () =>
                {
                    if (await roleManager.RoleExistsAsync("Administrator")
                        && await roleManager.RoleExistsAsync("Technician")
                    )
                    {
                        return;
                    }
                    var roles = new string[] {"Administrator", "Technician" };

                    foreach (var item in roles)
                    {
                        var role = new IdentityRole { Name = item };
                        await roleManager.CreateAsync(role);
                    }

                    var admin = await userManager.FindByEmailAsync("admin@mail.com");
                    await userManager.AddToRoleAsync(admin, "Administrator");

                    var technicians = new string[] {
                        "technician1@mail.com",
                        "technician2@mail.com",
                        "technician3@mail.com"
                    };

                    foreach (var item in technicians)
                    {
                        var technician = await userManager.FindByEmailAsync(item);
                        await userManager.AddToRoleAsync(technician, "Technician");
                    }
                })
                .GetAwaiter()
                .GetResult();

            return app;
        }
    }
}
