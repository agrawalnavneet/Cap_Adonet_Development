using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// DB (InMemory)
builder.Services.AddDbContext<AppDbContext>(opt =>
    opt.UseInMemoryDatabase("TestDb"));

// Redis
builder.Services.AddSingleton<IConnectionMultiplexer>(
    ConnectionMultiplexer.Connect("localhost:6379"));

// Services
builder.Services.AddScoped<RedisService>();
builder.Services.AddScoped<StockService>();

// MediatR (CQRS)
builder.Services.AddMediatR(typeof(Program));

// Controllers
builder.Services.AddControllers();

// Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();