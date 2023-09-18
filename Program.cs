using System.Text;
using AutoDealer.Data;
using AutoDealer.Entities.Models.Auth;
using AutoDealer.JwtFeatures;
using AutoDealer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddCors(options => options.AddDefaultPolicy(builder =>
{
    // builder.WithOrigins("http://localhost:5046").AllowAnyHeader().AllowAnyMethod();
    builder.AllowAnyOrigin();
}));

var connString = builder.Configuration.GetConnectionString("AutoDbContext");
builder.Services.AddSqlServer<AutoDbContext>(connString);
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AutoDbContext>();

builder.Services.AddAutoMapper(typeof(Program));

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("securityKey").Value!))
    };
});
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<JwtHandler>();
builder.Services.AddScoped<IAccountsService, AccountsService>();
builder.Services.AddScoped<IAutoService, AutoService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auto}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
