using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class CursoConfigurations : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("TB_Curso");

        builder.HasKey(c => c.Id)
        .HasName("PK_TBCurso");

        builder.Property(c => c.Id)
        .ValueGeneratedNever();

        builder.Property(c => c.Nome)
        .HasMaxLength(100).IsRequired();

        builder.Property(c => c.CargaHoraria)
        .IsRequired();

        builder.Property(c => c.Dificuldade)
        .HasConversion<int>().IsRequired();

        builder.HasOne(c => c.Categoria)
        .WithMany()
        .HasForeignKey("CategoriaId")
        .HasConstraintName("FK_TBCurso_TBCategoria")
        .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(c => c.Aulas)      
           .WithOne(a => a.Curso)     
           .HasForeignKey("CursoId")   
           .HasConstraintName("FK_TBAula_TBCurso")
           .OnDelete(DeleteBehavior.NoAction);
    }
}