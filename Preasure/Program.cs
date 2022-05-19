using DbServices;
using EFCore;
using Microsoft.EntityFrameworkCore;
using Services;

var builder = WebApplication.CreateBuilder(args);
ConfigureServices(builder.Services, builder.Configuration);

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseEndpoints(endpoints =>
{

   // endpoints.MapControllerRoute("default", "{controller=Public}/{action=Index}/{id?}");

    endpoints.MapRazorPages();
       
});

app.UseAuthorization();


app.Run();


void ConfigureServices(IServiceCollection services, ConfigurationManager configuration)
{

    services.AddControllersWithViews();
    services.AddScoped<IDynamicDbService, DynamicDbService>();
}

