using EscolaDeCursos.Aplicacao;
using EscolaDeCursos.Infra;
using EscolaDeCursos.WebApp.Compartilhado;

var builder = WebApplication.CreateBuilder(args);

// Configuração do container de injeção de dependência
builder.Services.AddInfraRepositories(builder.Configuration, builder.Logging);
builder.Services.AddPresentationConfig(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);

var app = builder.Build();

// Middlewares de roteamento
app.UseRouting();
//diddlewares de Auth
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();

// Execução do Servidor
app.Run();
