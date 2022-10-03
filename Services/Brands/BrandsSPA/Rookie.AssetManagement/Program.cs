using Services.Brands.BrandsSPA.Rookie.AssetManagement.Extensions.ServiceCollection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Middlewares;
using System.Text.Json;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;
using System.Reflection;
using Microsoft.AspNetCore.Identity;
using System;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.Business;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Data.Seeds;
using Services.Brands.BrandsSPA.Rookie.AssetManagement.DataAccessor.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthenticationRegister();
builder.Services.AddHttpContextAccessor();
builder.Services.AddDataAccessorLayer(builder.Configuration);
builder.Services.AddBusinessLayer();

builder.Services.AddControllers()
    .AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            fv.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
        })
    .AddJsonOptions(ops =>
        {
            ops.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
            ops.JsonSerializerOptions.WriteIndented = true;
            ops.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            ops.JsonSerializerOptions.DictionaryKeyPolicy = JsonNamingPolicy.CamelCase;
            ops.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
        });

builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "Frontend/build";
});
builder.Services.AddSwagger();

//delare cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        builder =>
        {
            builder.WithOrigins("https://localhost:5001")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();
        await DefaultUsers.SeedAsync(userManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex);
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Rookie.AssetManagement v1"));
}
else
{
    app.UseMiddleware<ErrorHandler>();
}

app.UseHttpsRedirection();
app.UseSpaStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.UseSpa(spa =>
{
    spa.Options.SourcePath = "Frontend";

    if (app.Environment.IsDevelopment())
    {
        spa.UseReactDevelopmentServer(npmScript: "start");
    }
});

app.Run();