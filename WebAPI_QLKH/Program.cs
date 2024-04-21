using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI_QLKH.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Set up configuration
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
builder.Services.AddDbContext<QLKH_ThuocContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

var app = builder.Build();
var connectionString = app.Configuration.GetConnectionString("MyConnection");

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
