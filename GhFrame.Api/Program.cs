using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using System.Text.Json;
using GhFrame.Api.Abstractions;
using GhFrame.Api.Data;
using GhFrame.Api.Endpoints;
using GhFrame.Api.Identity;
using GhFrame.Api.Models;
using GhFrame.Api.Options;
using GhFrame.Api.Services;
using GhFrame.Api.Abstractions.Repositories;
using GhFrame.Api.Repositories;
using GhFrame.Api.Abstractions.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();

builder.Services.AddDbContext<ApplicationDbContext>((options) =>
{
    var connectionString = builder.Configuration.GetConnectionString("Database");
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));

});

builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddOptionsWithValidateOnStart<JwtOptions>()
    .BindConfiguration(JwtOptions.SectionName)
    .ValidateDataAnnotations();
    
builder.Services.AddSingleton<IValidateOptions<JwtOptions>, ValidateJwtOptions>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SameSite = SameSiteMode.Strict;
});

var tokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidAudience = builder.Configuration["Jwt:ValidAudience"],
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = builder.Configuration["Jwt:ValidIssuer"],
    IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Secret"]!)),
    ClockSkew = TimeSpan.Zero
};

builder.Services.AddSingleton(tokenValidationParameters);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
    .AddJwtBearer(options =>
    {
        options.SaveToken = true;
        options.TokenValidationParameters = tokenValidationParameters;
    });

builder.Services.ConfigureOptions<JwtBearerOptionsSetup>();

builder.Services.AddAuthorizationBuilder();

builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IWarehouseService, WarehouseService>();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, ApplicationAuthorizationPolicyProvider>();
builder.Services.AddTransient<IClaimsTransformation, PermissionClaimsTransformation>();

builder.Services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
builder.Services.AddScoped<IWarehouseRepository, WarehouseRepository>();
builder.Services.AddScoped<IJwtProvider, JwtProvider>();

builder.Services.ConfigureHttpJsonOptions(options =>
{
    options.SerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
});

const string defaultCorsPolicyName = "Default";

builder.Services.AddCors(options =>
{
    var origins = builder.Configuration.GetSection("ClientOrigins").Get<string[]>()!;

    options.AddPolicy(defaultCorsPolicyName, policy =>
    {
        policy.WithOrigins(origins)
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization: Bearer {token}",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
            },
            new List<string>()
        }
    });
});

builder.Services.AddAntiforgery(options => options.HeaderName = "X-XSRF-TOKEN");


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();

    await app.SeedDatabaseAsync(app.Configuration);
}

app.UseHttpsRedirection();
app.UseCookiePolicy();
app.UseCors(defaultCorsPolicyName);

app.UseAuthentication();
app.UseAuthorization();

app.UseAntiforgery();

app.MapGet("antiforgery/token", (IAntiforgery forgeryService, HttpContext context) =>
{
    var tokens = forgeryService.GetAndStoreTokens(context);
    context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!,
            new CookieOptions { HttpOnly = false });

    return Results.Ok();
});

app.MapAuthenticationEndpoints();
app.MapAuthorizationEndpoints();
app.MapControllers();



await app.RunAsync();