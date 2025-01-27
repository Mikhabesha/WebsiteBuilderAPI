using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebsiteBuilderAPI.Data;
using WebsiteBuilderAPI.Services;
using WebsiteBuilderAPI.Data.WebsiteBuilderAPI.Data;



var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUserService, UserService>();

// Add authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "YourAuthorityHere";
        options.RequireHttpsMetadata = false;
        options.Audience = "api";
    });

// Add controllers
builder.Services.AddControllers();

// Add localization for multi-language support
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder => builder
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

app.UseCors("AllowReactApp");

// Register services
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IWebsiteService, WebsiteService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors(policy =>
    policy.AllowAnyOrigin()
          .AllowAnyMethod()
          .AllowAnyHeader());

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
