using Model;
using StubLib;
using Microsoft.AspNetCore.Mvc.Versioning;
using Console_Champions;
using EFDataManager;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IDataManager, StubData>();
//builder.Services.AddScoped<IDataManager, IEFDataManager>();

builder.Services.AddApiVersioning(o => o.ApiVersionReader = new UrlSegmentApiVersionReader());

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
