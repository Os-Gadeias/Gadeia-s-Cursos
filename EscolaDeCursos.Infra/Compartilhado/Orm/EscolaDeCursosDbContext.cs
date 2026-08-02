using System.Reflection;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Compartilhado.Identity;
using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloInstituicao;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Compartilhado.Orm;

public sealed class EscolaDeCursosDbContext(
    DbContextOptions<EscolaDeCursosDbContext> options, IUserProvider? userProvider = null)
    : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>(options)
{
    public DbSet<Categoria> Categorias => Set<Categoria>();
    public DbSet<Tutor> Tutores => Set<Tutor>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Aula> Aulas => Set<Aula>();
    public DbSet<Instituicao> Insituicoes => Set<Instituicao>();
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        Assembly assembly = typeof(EscolaDeCursosDbContext).Assembly;

        modelBuilder.ApplyConfigurationsFromAssembly(assembly);

        Guid? userId = userProvider?.Id;

        modelBuilder.Entity<Categoria>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);


        modelBuilder.Entity<Aula>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);


        modelBuilder.Entity<Curso>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);


        modelBuilder.Entity<Turma>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);


        modelBuilder.Entity<Tutor>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);


        modelBuilder.Entity<Matricula>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);


        modelBuilder.Entity<Instituicao>()
        .HasQueryFilter(c => c.UserId == userProvider!.Id);

        base.OnModelCreating(modelBuilder);
    }

    public override int SaveChanges()
    {
        Guid? userId = userProvider?.Id;

        if (!userId.HasValue)
        {
            throw new UnauthorizedAccessException(
                "Não é possivel salvar entidades da instituicao sem estar autenticado!"
            );
        }

        foreach (var entry in ChangeTracker.Entries<IEntidadeUsuario>())
        {
            switch (entry.State)
            {
                case EntityState.Added:
                    if (entry.Entity.UserId == Guid.Empty)
                    {
                        entry.Property(nameof(IEntidadeUsuario.UserId)).CurrentValue = userId;
                    }
                    else if (entry.Entity.UserId != userId)
                    {
                        throw new UnauthorizedAccessException(
                            "Tentativa de Criar entidade para outra instituição!"
                         );
                    }
                    break;

                case EntityState.Modified:

                    Guid idInstituicaoOriginal = entry
                    .Property(nameof(IEntidadeUsuario.UserId))
                    .OriginalValue is Guid originalGuid
                    ? originalGuid : Guid.Empty;

                    Guid idAtualIntituicao = entry.
                    Property(nameof(IEntidadeUsuario.UserId))
                    .OriginalValue is Guid idAtual
                    ? idAtual : Guid.Empty;

                    if (idAtualIntituicao != idInstituicaoOriginal)
                    {
                        throw new UnauthorizedAccessException(
                            "Não é permitido alterar a instituição de uma entidade!"
                         );
                    }

                    if (idAtualIntituicao != userId)
                    {
                        throw new UnauthorizedAccessException(
                            "Tentativa de Criar entidade para outra instituição!"
                         );
                    }
                    break;

                case EntityState.Deleted:

                    Guid InstituicaoOriginal = entry
                   .Property(nameof(IEntidadeUsuario.UserId))
                   .OriginalValue is Guid original
                   ? original : Guid.Empty;

                    if (InstituicaoOriginal != userId.Value)
                    {
                        throw new UnauthorizedAccessException(
                            "Tentativa de Criar entidade para outra instituição!"
                         );
                    }

                    break;
            }
        }

        return base.SaveChanges();
    }
}
