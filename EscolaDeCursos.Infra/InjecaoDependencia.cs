using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using EscolaDeCursos.Infra.Comartilhado.Logging;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using EscolaDeCursos.Infra.Modulos;
using EscolaDeCursos.Infra.Modulos.ModuloAula;
using EscolaDeCursos.Infra.Modulos.ModuloAluno;
using EscolaDeCursos.Infra.Modulos.ModuloCurso;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Modulos.ModuloMatricula;

namespace EscolaDeCursos.Infra;

public static class InjecaoDependencia
{
    public static void AddInfraRepositories(
        this IServiceCollection services,
        IConfiguration configuration,
        ILoggingBuilder logging
    )
    {
        // Injeta logs do Serilog
        Log.Logger = SerilogFactory.Create(configuration);

        logging.ClearProviders();

        services.AddSerilog(Log.Logger);

        // Injeta o DbContext do EF
        services.AddDbContext<EscolaDeCursosDbContext>(options =>
        {
            string? connectionString = configuration.GetConnectionString("SqlServerEF");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                throw new InvalidOperationException(
                    $"A connection string \"SqlServerEF\" não foi encontrada."
                );
            }

            options.UseSqlServer(connectionString, opt =>
            {
                opt.EnableRetryOnFailure(3);
            });
        });
        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
        services.AddScoped<IRepositorioTutor, RepositorioTutorEmOrm>();
        services.AddScoped<IRepositorioCurso, RepositorioCursoOrm>();
        services.AddScoped<IRepositorioAula, RepositorioAulaEmOrm>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmOrm>();
        services.AddScoped<IRepositorioTurma, RepositorioTurmaEmOrm>();
        services.AddScoped<IRepositorioMatricula, RepostitorioMatriculaEmOrm>();
    }
}
