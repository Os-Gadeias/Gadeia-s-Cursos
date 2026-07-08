using EscolaDeCursos.Infra;
using EscolaDeCursos.WebApp.Compartilhado;

var builder = WebApplication.CreateBuilder(args);

// Configuração do container de injeção de dependência

builder.Services.AddInfraRepositories(builder.Configuration, builder.Logging);
// TODO: Injetar camada de aplicação
builder.Services.AddPresentationConfig(builder.Configuration);

var app = builder.Build();

// Middlewares de roteamento
app.UseRouting();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
