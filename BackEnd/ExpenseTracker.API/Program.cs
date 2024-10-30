using ExpenseTracker.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ExpenseTrackerContext>(x =>
 {
     x.UseSqlServer(@"Server=localhost,1430;Database=CardManagementAPI;User Id=sa;Password=Pass@w0rd;TrustServerCertificate=true");
 });
builder.Services.AddScoped<ExpenseTrackerContext>();

builder.Services.AddMediatR(x =>
    x.RegisterServicesFromAssembly(Assembly.Load("ExpenseTracker.Application"))
    );


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
