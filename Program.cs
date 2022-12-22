using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddDbContext<TodoContext>(opt =>
    opt.UseInMemoryDatabase("TodoDb"));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();
//Config railway
var port = builder.Configuration["PORT"];

builder.WebHost.UseUrls($"http://*:{port};http://localhost:3000");

app.UseAuthorization();

app.MapControllers();

app.Run();

namespace TodoApi
{
    public partial class Program { }
}
