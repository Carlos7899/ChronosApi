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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ChronosApi.Repository.Vaga;
using ChronosApi.Services.Vaga;
using ChronosApi.Repository.Comentario;
using ChronosApi.Services.Comentario;
using ChronosApi.Services.Enderecos.VagaEndereco;
using ChronosApi.Repository.Enderecos.VagaEndereco;
using ChronosApi.Services.Candidatura;
using ChronosApi.Services.Curso;
using ChronosApi.Services.Enderecos.CursoEndereco;
using ChronosApi.Repository.Enderecos.CursoEndereco;
using ChronosApi.Services.Curriculo.Curriculo;
using ChronosApi.Services.Curriculo.Experiencia;
using ChronosApi.Services.Curriculo.formacao;
using ChronosApi.Services.Formacao;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DataContext>(Options =>
{
    Options.UseSqlServer(builder.Configuration.GetConnectionString("ConexaoLocal5"));
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers();

// Revisar
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        { 
           ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration.GetSection("configuracaoToken:Chave").Value ?? "")),
           ValidateIssuer = false,
           ValidateAudience = false
        };
    });

#region Scoped
builder.Services.AddScoped<ICorporacaoService, CorporacaoService>();
builder.Services.AddScoped<ICorporacaoRepository, CorporacaoRepository>();

builder.Services.AddScoped<IEgressoService, EgressoService>();
builder.Services.AddScoped<IEgressoRepository, EgressoRepository>();

builder.Services.AddScoped<IPublicacaoService, PublicacaoService>();
builder.Services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();

builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<IVagaRepository, VagaRepository>();

builder.Services.AddScoped<IComentarioService, ComentarioService>();
builder.Services.AddScoped<IComentarioRepository, ComentarioRepository>();

builder.Services.AddScoped<ICandidaturaService, CandidaturaService>();

builder.Services.AddScoped<ICursoService, CursoService>();

#region Curriculo

builder.Services.AddScoped<IFormacaoService, FormacaoService>();

builder.Services.AddScoped<ICurriculoService, CurriculoService>();

builder.Services.AddScoped<IExperienciaService, ExperienciaService>();

#endregion

#region Enderecos

builder.Services.AddScoped<ICursoEnderecoService, CursoEnderecoService>();
builder.Services.AddScoped<ICursoEnderecoRepository, CursoEnderecoRepository>();

builder.Services.AddScoped<ICorporacaoEnderecoService, CorporacaoEnderecoService>();
builder.Services.AddScoped<ICorporacaoEnderecoRepository, CorporacaoEnderecoRepository>();

builder.Services.AddScoped<ILogradouroService, LogradouroService>();
builder.Services.AddScoped<ILogradouroRepository, LogradouroRepository>();

builder.Services.AddScoped<IEgressoEnderecoService, EgressoEnderecoService>();
builder.Services.AddScoped<IEgressoEnderecoRepository, EgressoEnderecoRepository>();

builder.Services.AddScoped<IVagaEnderecoService, VagaEnderecoService >();
builder.Services.AddScoped<IVagaEnderecoRepository, VagaEnderecoRepository >();

#endregion

#endregion

// vagaCleanupService
builder.Services.AddHostedService<VagaCleanupService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
