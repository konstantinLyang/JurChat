using Microsoft.AspNetCore.Authentication.JwtBearer;
using Services.Abstractions;
using Services.Implementations;
using Web.App;
using Web.App.Hubs;
using Web.App.Hubs.Infrastructure;

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
