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

//Première version avec le Stub Data
//builder.Services.AddSingleton<IDataManager, StubData>();

//Passage eb utilisant le GeneralEFDataManager
builder.Services.AddDbContext<ChampionContext>();
builder.Services.AddScoped<IDataManager, GeneralEFDataManager>();

builder.Services.AddApiVersioning(o => o.ApiVersionReader = new UrlSegmentApiVersionReader());

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetService<ChampionContext>();
    context.Database.EnsureCreated();
}

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
