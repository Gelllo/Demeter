using Demeter.Application;
using FastEndpoints.Swagger;
using FastEndpoints;
using Microsoft.EntityFrameworkCore;
using Serilog.Sinks.MSSqlServer;
using Serilog;
using System.Collections.ObjectModel;
using System.Data;
using System.Reflection;
using System.Text;
using Demeter.Infrastracture.Dispatchers;
using Demeter.Infrastracture;
using Demeter.Web.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
    .AddJsonFile("appsettings.json")
    .Build();

ConfigurationManager configuration = builder.Configuration;

builder.ConfigureSerilog();
builder.ConfigureDatabase();

// Add services to the container.

builder.Services.AddFastEndpoints();
builder.Services.AddSwaggerDoc();

builder.Services.ConfigureAutoMapper();

builder.Services.ConfigureHandlers();

builder.Services.AddHttpClient();

builder.Services.AddAuthentication(x =>
    {
        x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddCookie(x =>
    {
        x.Cookie.Name = "token";
    })
    .AddJwtBearer(x =>
    {
        x.RequireHttpsMetadata = false;
        x.SaveToken = false;
        x.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey =
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["ApplicationSettings:Secret"])),
            ValidateIssuer = false,
            ValidateAudience = false
        };
        x.Events = new JwtBearerEvents()
        {
            OnMessageReceived = context =>
            {
                context.Token = context.Request.Cookies["X-Access-Token"];
                return Task.CompletedTask;
            }
        };
    });

builder.Services.AddCors(opt =>
{
    opt.AddPolicy("CorsPolicy", builder =>
        builder.WithOrigins("https://localhost:4200", "http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseFastEndpoints();
app.UseCors("CorsPolicy");

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
    app.UseSwaggerUi3();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.Run();
