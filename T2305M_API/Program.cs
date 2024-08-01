using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// connect db
T2305M_API.Entities.T2305mApiContext.ConnectionString = builder.Configuration.GetConnectionString("T2305M_API");
builder.Services.AddDbContext<T2305M_API.Entities.T2305mApiContext>(
    options => options.UseSqlServer(T2305M_API.Entities.T2305mApiContext.ConnectionString)
    );
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

