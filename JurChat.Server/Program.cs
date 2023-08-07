using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using JurChat.Server.Infrastructure.EntityFramework;
using JurChat.Server.Infrastructure.Repositories.Implementations;
using JurChat.Server.Services.Abstractions;
using JurChat.Server.Services.Implementations;
using JurChat.Web;
using JurChat.Web.Hubs;
using JurChat.Web.Hubs.Infrastructure;
using JurChat.Web.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();

#region Infrastructure services

builder.Services.AddTransient<IUserService, UserService>();

#endregion

builder.Services.AddSingleton<ChatHubManager>();
builder.Services.AddAutoMapper(typeof(AppMappingProfile));

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.Events = new JwtBearerEvents
        {
            OnMessageReceived = context =>
            {
                var accessToken = context.Request.Query["access_token"];

                // если запрос направлен хабу
                var path = context.HttpContext.Request.Path;
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chat"))
                {
                    // получаем токен из строки запроса
                    context.Token = accessToken;
                }
                return Task.CompletedTask;
            }
        };
    });

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapPost("/login", (UserModel loginModel) =>
{
    var person = userService.FirstOrDefault(p => p.Mail == loginModel.Mail && p.Password == loginModel.Password);

    if (person is null) return Results.Unauthorized();

    var claims = new List<Claim> { new (ClaimTypes.Name, person.Mail) };

    var jwt = new JwtSecurityToken(
        issuer: AuthOptions.ISSUER,
        audience: AuthOptions.AUDIENCE,
        claims: claims,
        expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
        signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
    var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

    var response = new
    {
        access_token = encodedJwt,
        username = person.Mail
    };

    return Results.Json(response);
});

app.MapHub<ChatHub>("/chat");

app.Run();

namespace JurChat.Web
{
    public class AuthOptions
    {
        public const string ISSUER = "MyAuthServer"; // издатель токена
        public const string AUDIENCE = "MyAuthClient"; // потребитель токена
        const string KEY = "mysupersecret_secretkey!123";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}