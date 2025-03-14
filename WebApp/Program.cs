using FluentValidation.AspNetCore;
using WebApp.Validators;
using Infrastructure.Context; // AppDbContext i kullanmak için
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Infrastructure.Services;
using Infrastructure.Interfaces;


var builder = WebApplication.CreateBuilder(args);

// Connection String'i appsettings.json'dan oku
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Infrastructure içindeki DbContext'i servislere ekle ynai bu baðlantýyý artýk kullanabilisin
//builder.Services.AddDbContext<AppDbContext>(options =>
//    options.UseSqlServer(connectionString)
//    );
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.ConfigureWarnings(warnings =>
        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
});

builder.Services.AddTransient<IStudentService, StudentService>();

// Add services to the container.
builder.Services.AddControllersWithViews();


// Fluent Validation'ý DI (Dependency Injection) 
builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<StudentValidator>());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
