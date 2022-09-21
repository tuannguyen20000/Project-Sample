using Pratical.SignalRWebPack.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
var app = builder.Build();
app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<AgentChatHub>("/hub");
app.Run();
