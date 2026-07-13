using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Modulos.ModuloTurma;

public class TurmaConfigurations : IEntityTypeConfiguration<Turma>
{
    public void Configure(EntityTypeBuilder<Turma> builder)
    {
        builder.ToTable("TBTurma");

        builder.HasKey(t => t.Id)
        .HasName("PK_TBCurso");

        builder.Property(c => c.Id)
        .ValueGeneratedNever();

        builder.Property(t => t.Titulo)
        .HasMaxLength(100).IsRequired();

        builder.Property(t => t.CapacidadeMaxima)
        .IsRequired();

        builder.Property(t => t.DataInicio).
        IsRequired();

        builder.Property(t => t.DataTermino).
        IsRequired();

        builder.HasOne(t => t.Curso)
        .WithMany()
        .HasForeignKey("CursoId")
        .HasConstraintName("FK_TBCurso_TBTurma")
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(t => t.Tutor)
        .WithMany()
        .HasForeignKey("TutorId")
        .HasConstraintName("FK_TBTutor_TBTurma")
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(t => t.Alunos)
        .WithOne()
        .HasForeignKey("AlunoId")
        .HasConstraintName("FK_TBAluno_TBTurma")
        .OnDelete(DeleteBehavior.NoAction);
    }
}
