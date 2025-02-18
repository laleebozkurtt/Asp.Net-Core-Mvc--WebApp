using FluentValidation.AspNetCore;
using WebApp.Validators;
using Infrastructure.Context; // AppDbContext i kullanmak i�in
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Connection String'i appsettings.json'dan oku
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");


// Infrastructure i�indeki DbContext'i servislere ekle ynai bu ba�lant�y� art�k kullanabilisin
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

// Add services to the container.
builder.Services.AddControllersWithViews();

// Fluent Validation'� DI (Dependency Injection) 
builder.Services.AddFluentValidation(fv =>fv.RegisterValidatorsFromAssemblyContaining<StudentValidator>());

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
