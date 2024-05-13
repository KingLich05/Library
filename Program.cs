using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using sultan.Application;
using sultan.Service;
using sultan.Service.Impls;


var builder = WebApplication.CreateBuilder();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(); 
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(Jwt.jwt);
builder.Services.AddAuthorization();



builder.Services.AddScoped<IUsersService, UserService>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookAndUserService, BookAndUserService>();

builder.Services.AddHttpClient();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseSession(); 

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Users}/{action=auth}/{id?}");

app.Map("/hello",[Authorize] () => "Hello World!");



app.Run();