using Microsoft.EntityFrameworkCore;
using ChronosApi.Data;
using ChronosApi.Services.Corporacao;
using ChronosApi.Repository.Corporacao;
using ChronosApi.Services.Egresso;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region Scoped
builder.Services.AddScoped<ICorporacaoService, CorporacaoService>();
builder.Services.AddScoped<ICorporacaoRepository, CorporacaoRepository>();

builder.Services.AddScoped<IEgressoService, EgressoService>();
builder.Services.AddScoped<IEgressoRepository, EgressoRepository>();
#endregion

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
