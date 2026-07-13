using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class MatriculaConfigurations : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("TB_Matricula");

        builder.HasKey(m => m.Id)
        .HasName("PK_Matricula");

        builder.Property(m => m.Id)
        .ValueGeneratedNever();

        builder.Property(m => m.DataMatricula)
        .IsRequired();

        builder.HasOne(m => m.Aluno)
        .WithMany()
        .HasForeignKey("AlunoId")
        .HasConstraintName("FK_TBAluno_TBMatricula")
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(m => m.Turma)
        .WithMany()
        .HasForeignKey("TurmaId")
        .HasConstraintName("FK_TBTurma_TBMatricula")
        .OnDelete(DeleteBehavior.NoAction);
    }
}
