using FixIt.Core.Profiles;
using FixIt.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationDbContext(builder.Configuration);
builder.Services.AddApplicationIdentity(builder.Configuration);
builder.Services.AddAutoMapper(cfg => cfg.AddProfile<MapperConfig>(), typeof(Program));

builder.Services.AddControllersWithViews();

builder.Services.AddApplicationServices();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.SeedAdmin();

app.MapDefaultControllerRoute();
app.MapRazorPages();

await app.RunAsync();
