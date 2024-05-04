using Microsoft.AspNetCore.Authentication.JwtBearer;
using sultan.Application;
using sultan.Service;
using sultan.Service.Impls;

var builder = WebApplication.CreateBuilder();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(); 
builder.Services.AddControllersWithViews();


builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Jwt.jwt);
builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.UseSession(); 
app.UseHttpsRedirection();
app.UseRouting();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=auth}/{id?}");

app.Run();