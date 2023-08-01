using JurChat.Server.Hubs;
using JurChat.Server.Hubs.Infrastructure;
using JurChat.Server.Persistence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>();
builder.Services.AddSingleton<ChatHubManager>();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.MapHub<ChatHub>("/chat");

app.Run();
