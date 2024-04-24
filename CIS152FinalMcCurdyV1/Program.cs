using CIS152FinalMcCurdyV1.DAL;
using CIS152FinalMcCurdyV1.Data;
using CIS152FinalMcCurdyV1.Data.Enum;
using CIS152FinalMcCurdyV1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DrinkShopAppContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DrinkShopAppContext") ?? throw new InvalidOperationException("Connection string 'DrinkShopAppContext' not found.")));

// Add services to the container.
builder.Services.AddControllersWithViews();
// Below is setting up the database, then going to appsettings.json file - need to add
// the connection string to the appsettings.json file. 
/*builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});*/
// versus ?? - change name of DbContext from ApplicationDbContext to DrinkShopDbContext
/*builder.Services.AddDbContext<DrinkShopDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DrinkShopDatabase"));
});*/

var app = builder.Build();

/*using (var context = new DrinkShopAppContext())
{
    //System.Data.Entity.Database.SetInitializer<DrinkShopAppContext>(new ShopInitializer());
    //System.Data.Entity.Database.SetInitializer<DrinkShopAppContext>(new ShopInitializer());
    System.Data.Entity.Database.SetInitializer(new ShopInitializer());
}*/

/*using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    SeedData.Initialize(services);
}*/

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

