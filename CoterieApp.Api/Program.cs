using AutoMapper;
using CoterieApp.App;
using CoterieApp.App.Services;
using CoterieApp.App.Services;
using CoterieApp.Data.Context;
using Microsoft.EntityFrameworkCore;
using AssesmentCoterie.App.Services;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddTransient<IStateService, StateService>();
builder.Services.AddTransient<IBusinessService, BusinessService>();
builder.Services.AddTransient<IQuoteEngineService, QuoteEngineService>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<CoterieAppContext>(op =>
{
    op.UseSqlite(configuration.GetConnectionString("QuotesDB"));
});

builder.Services.AddAutoMapper(typeof(Program));

var mapperConfig = new MapperConfiguration(m =>
{
    m.AddProfile(new MapperProfiles());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

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
