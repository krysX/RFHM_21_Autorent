using System.Text;
using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;
using AutorentServer.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.WebSockets;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = "Team21_AutorentServer",
            ValidAudience = "Team21_AutorentClient",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("eztNemFejtiMegSenki_amugyDeMertBarkiLathatja"))
        };
    });

builder.Services.AddDbContext<AutorentContext>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICarService, CarService>();

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// db.Add(new Car { Id = 0, Brand = "kdfsjl", Model = "sjdflk", CategoryId = 1, DailyPrice = 9600 });
// db.SaveChanges();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseFileServer();

app.UseAuthorization();
app.UseWebSockets();

app.MapControllers();

app.Run();
