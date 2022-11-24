using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PTC_NET_Backend.Controllers.Mappers;
using PTC_NET_Backend.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<PtcDbContext>(options =>
    options.UseSqlServer((builder.Configuration.GetConnectionString("PtcDbDefaultConnection"))));
builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Mappers
var mappingConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new UserMoodMapping());
});
builder.Services.AddSingleton(mappingConfig.CreateMapper());

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