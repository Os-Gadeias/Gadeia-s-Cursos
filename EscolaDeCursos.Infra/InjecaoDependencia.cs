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
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

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

        // configuração do usuario do Identity
        services.AddIdentityCore<IdentityUser<Guid>>(options =>
        {
            options.User.RequireUniqueEmail = true; // Email Exclusivo?
            options.SignIn.RequireConfirmedEmail = false; // E nessesario confirmar o email?
            options.Password.RequiredLength = 8; // quantidade de caracteres
            options.Password.RequireDigit = true;   // ter um numero
            options.Password.RequireNonAlphanumeric = true; // caracter alfa numerico
            options.Password.RequireUppercase = false; // Letra maiuscula?
            options.Password.RequireLowercase = false; // Letra minuscula?
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // trancar acesso por 5 mim
            options.Lockout.MaxFailedAccessAttempts = 5; // maximo de tentativas de lockout 5
            options.Lockout.AllowedForNewUsers = true; // lockout usuario
        })
        .AddRoles<IdentityRole<Guid>>()
        .AddEntityFrameworkStores<EscolaDeCursosDbContext>()
        .AddSignInManager()
        .AddDefaultTokenProviders();

        services.AddScoped<IRepositorioCategoria, RepositorioCategoriaEmOrm>();
        services.AddScoped<IRepositorioTutor, RepositorioTutorEmOrm>();
        services.AddScoped<IRepositorioCurso, RepositorioCursoOrm>();
        services.AddScoped<IRepositorioAula, RepositorioAulaEmOrm>();
        services.AddScoped<IRepositorioAluno, RepositorioAlunoEmOrm>();
        services.AddScoped<IRepositorioTurma, RepositorioTurmaEmOrm>();
        services.AddScoped<IRepositorioMatricula, RepostitorioMatriculaEmOrm>();
    }
}
