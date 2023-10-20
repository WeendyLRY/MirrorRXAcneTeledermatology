using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AcneTeledermatology.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);




builder.Services.AddDefaultIdentity<AcneTeledermatology.Models.User>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<AcneTeleContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<AcneTeleContext>(options =>
    
options.UseSqlServer(builder.Configuration.GetConnectionString("AcneTeleContext") ?? throw new InvalidOperationException("Connection string 'AcneTeleContext' not found.")));




builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddHttpClient();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
     
    var context = services.GetRequiredService<AcneTeleContext>();
    context.Database.EnsureCreated();
    //context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[User] ON");
   
   // DbInitializer.Initialize(context);
   // context.Database.ExecuteSqlRaw("SET IDENTITY_INSERT dbo.[User] OFF");
  



}





app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();


app.UseSession();

app.MapRazorPages();

app.Run();
