using Microsoft.EntityFrameworkCore;
using mysql_database.Data;

var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MySqlServerVersion(new Version(8, 2, 0));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SakilaContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("mysql_sakila"));
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

builder.Services.AddDbContext<CatsContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("cats"), serverVersion);
    options.EnableSensitiveDataLogging();
    options.EnableDetailedErrors();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
