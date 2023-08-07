using JurChat.Server.Services.Abstractions;
using JurChat.Server.Services.Implementations;
using JurChat.Web;
using JurChat.Web.Hubs;
using JurChat.Web.Hubs.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

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

                var path = context.HttpContext.Request.Path;
                
                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/chat")) context.Token = accessToken;
                
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


app.MapHub<ChatHub>("/chat");

app.Run();
