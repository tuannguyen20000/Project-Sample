using Ocelot.Provider.Eureka;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Provider.Polly;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);


builder.Configuration.AddJsonFile("ocelot.json", optional: false, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration).AddEureka()
    .AddCacheManager(x =>
    {
        x.WithDictionaryHandle();
    }).AddPolly();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy", builder =>
        builder.AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials().SetIsOriginAllowed((hosts) => true));
});

var app = builder.Build();
app.UseCors("CORSPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();

await app.UseOcelot();

app.UseAuthorization();

app.Run();
