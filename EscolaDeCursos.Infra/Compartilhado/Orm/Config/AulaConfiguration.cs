using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class AulaConfiguration : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.ToTable("TB_Aula");

        builder.HasKey(a => a.Id)
        .HasName("PK_TBAula");

        builder.Property(c => c.Id).
            ValueGeneratedNever();

        builder.Property(c => c.Nome)
        .HasMaxLength(30).IsRequired();

        builder.Property(c => c.Duracao)
        .IsRequired();

        builder.HasOne(a => a.Curso)
        .WithMany(c => c.Aulas)
        .HasForeignKey("CursoId")
        .HasConstraintName("FK_TBAula_TBCurso")
        .OnDelete(DeleteBehavior.NoAction);
    }
}
