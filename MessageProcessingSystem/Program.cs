using AutoMapper;
using Mapper;
using Microsoft.EntityFrameworkCore;
using Model;
using Repository;
using Service;
using static Mapper.MapperConfig;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IMessageProcessingSystemRepository, MessageProcessingSystemRepository>();
builder.Services.AddScoped<IServiceA, ServiceA>();
builder.Services.AddScoped<IServiceB, ServiceB>();
builder.Services.AddScoped<IServiceC, ServiceC>();
builder.Services.AddStackExchangeRedisCache(redisOption =>
{
    var connctiom = builder.Configuration.GetConnectionString("Redis");
    redisOption.Configuration= connctiom;
});
// Auto Mapper Configurations
var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MappingProfile());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);



builder.Services.AddDbContext<MessageDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

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
