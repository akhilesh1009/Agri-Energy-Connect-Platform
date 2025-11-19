using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ST10281011_PROG7311_POE_PART_2.Data;
using ST10281011_PROG7311_POE_PART_2.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AgriEnergy")));

//add identiy services
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().
    AddEntityFrameworkStores<ApplicationDbContext>();

var app = builder.Build();

//Source: tutorialsEU - C# (2023) ASP.NET User Roles - Create and Assign Roles for AUTHORIZATION!, 23 February.
//Avaliable At: <https://www.youtube.com/watch?v=Y6DCP-yH-9Q> [Accessed 12 May 2025]

//Seeding Roles
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
    var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

    string[] roles = new[] { "Employee", "Farmer" };
    foreach (var role in roles)
    {
        if (!roleManager.RoleExistsAsync(role).Result)
        {
            roleManager.CreateAsync(new IdentityRole(role)).Wait();
        }
    }

    // Create Employee User
    string employeeEmail = "akhilesh.employee@gmail.com";
    string employeePassword = "Pa$$w0rd";
    string employeePhoneNumber = "0986754554";

    var employeeUser = await userManager.FindByEmailAsync(employeeEmail);
    if (employeeUser == null)
    {
        employeeUser = new IdentityUser
        {
            UserName = employeeEmail,
            Email = employeeEmail,
            PhoneNumber = employeePhoneNumber,
            EmailConfirmed = true
        };

        await userManager.CreateAsync(employeeUser, employeePassword);
        await userManager.AddToRoleAsync(employeeUser, "Employee");
    }
}
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

    app.Run();
