using AutoMapper;
using controle_de_contas_api;
using controle_de_contas_api.Domain;
using controle_de_contas_api.DTOs;
using controle_de_contas_api.Service;
using MongoDB.Bson.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var config = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<Competencia, CompetenciaDTO>().ReverseMap();
    cfg.CreateMap<Conta, ContaDTO>().ReverseMap();
});

var mapper = config.CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("Database"));

builder.Services.AddSingleton<CompetenciaService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "_enable",
                      builder =>
                      {
                          builder.WithOrigins("http://127.0.0.1:5500").AllowAnyHeader().AllowAnyMethod();
                      });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("_enable");

app.Run();