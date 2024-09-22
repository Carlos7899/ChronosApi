using Microsoft.EntityFrameworkCore;
using ChronosApi.Data;
using ChronosApi.Services.Corporacao;
using ChronosApi.Repository.Corporacao;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal2"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ICorporacaoService, CorporacaoService>();
builder.Services.AddScoped<ICorporacaoRepository, CorporacaoRepository>();

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
