using Pratical.SignalRWebPack.Hubs;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
                        build =>
                        {
                            build.WithOrigins("https://localhost:5001").AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                        });
});
var app = builder.Build();

app.UseCors("CorsPolicy");

app.UseDefaultFiles();
app.UseStaticFiles();

app.MapHub<AgentChatHub>("/hub");
app.Run();
