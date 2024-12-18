using Microsoft.EntityFrameworkCore;
using ASPInventory.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Adding Service for DbContext so that our application knows which DbContext to use and to use which database (sql server here)
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection") // this tells the exact database to use
    ));


//Razor runtime compilation added (Need nuget package to be installed first for razor runtime compilation)
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

//Make sure to add all services just above this
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
