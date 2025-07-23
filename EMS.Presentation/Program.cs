using EMS.Common;
using EMS.Service;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEmployeeDependencies(builder.Configuration);  // Service + repository DI class
builder.Services.AddCommonLayer(); // common layer DI class call hua

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
