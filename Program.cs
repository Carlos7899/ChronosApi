using Microsoft.EntityFrameworkCore;
using ChronosApi.Data;
using ChronosApi.Services.Corporacao;
using ChronosApi.Repository.Corporacao;
using ChronosApi.Services.Egresso;
using ChronosApi.Repository.Egresso;
using ChronosApi.Services.CorporacaoEndereco;
using ChronosApi.Repository.CorporacaoEndereco;
using ChronosApi.Services.Logradouro;
using ChronosApi.Repository.Enderecos.Logradouro;
using ChronosApi.Repository.Logradouro;
using ChronosApi.Repository.Enderecos.EgressoEndereco;
using ChronosApi.Services.EgressoEndereco;
using ChronosApi.Services.Publicacao;
using ChronosApi.Repository.Publicacao;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal4"));
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

builder.Services.AddScoped<ICorporacaoEnderecoService, CorporacaoEnderecoService>();
builder.Services.AddScoped<ICorporacaoEnderecoRepository, CorporacaoEnderecoRepository>();

builder.Services.AddScoped<ILogradouroService, LogradouroService>();
builder.Services.AddScoped<ILogradouroRepository, LogradouroRepository>();

builder.Services.AddScoped<IEgressoEnderecoService, EgressoEnderecoService>();
builder.Services.AddScoped<IEgressoEnderecoRepositorio, EgressoEnderecoRepositorio>();

builder.Services.AddScoped<IPublicacaoService, PublicacaoService>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();

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
