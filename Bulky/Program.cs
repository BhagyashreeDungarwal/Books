using Bulky.DataAccess;
using Bulky.DataAccess.Repository;
using Bulky.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);
//public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{
    // Add services to the container.
    builder.Services.AddControllersWithViews();

    builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDataProtection().SetApplicationName("Bulky")
    .PersistKeysToFileSystem(new DirectoryInfo(@"E:\\BHAGYASHREE\DotNetMVC\Bulky"))
    .ProtectKeysWithDpapi();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

    builder.Services.AddDefaultIdentity<IdentityUser>()
      .AddEntityFrameworkStores<ApplicationDbContext>()
      .AddDefaultUI()
    .AddDefaultTokenProviders();

//builder.Services.AddIdentity<IdentityUser, IdentityRole>()
  //  .AddEntityFrameworkStores<ApplicationDbContext>()
    //.AddDefaultUI()
    //.AddDefaultTokenProviders();
//builder.Services.AddTransient<IUnitOfWork, UnitOfWork>();
    
    builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

       var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else { 
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }
    //Middle Ware of pipe line
    app.UseHttpsRedirection();
    app.UseStaticFiles();

    app.UseRouting();
    app.UseAuthentication();

app.UseAuthorization();
    app.MapRazorPages();

    app.MapControllerRoute(
        name: "default",
        pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

    app.Run();
//}
