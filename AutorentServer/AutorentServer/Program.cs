using AutorentServer.Domain;
using AutorentServer.Domain.Models;
using AutorentServer.Domain.Repository;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

builder.Services.AddDbContext<AutorentContext>();
builder.Services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();

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

app.MapControllers();

app.Run();
