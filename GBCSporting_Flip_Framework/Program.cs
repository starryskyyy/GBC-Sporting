using GBCSporting_Flip_Framework.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(options =>
{
    options.LowercaseUrls = true;
    options.AppendTrailingSlash = true;
}
);
// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<GBCSportingContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("GBCSportingContext"))
);
var app = builder.Build();
app.UseDeveloperExceptionPage();
app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}/{slug?}");

app.Run();
