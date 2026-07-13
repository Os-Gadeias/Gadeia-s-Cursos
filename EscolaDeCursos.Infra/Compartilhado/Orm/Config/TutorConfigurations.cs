using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

class TutorConfiguration : IEntityTypeConfiguration<Tutor>
{
    public void Configure(EntityTypeBuilder<Tutor> builder)
    {
        builder.ToTable("TB_Tutor");

        builder.HasKey(t => t.Id)
            .HasName("PK_TBTutor");

        builder.Property(t => t.Id)
            .ValueGeneratedNever();

        builder.Property(t => t.Nome)
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(t => t.Telefone)
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(t => t.Cpf)
            .HasMaxLength(11)
            .IsRequired();

        // Indice Unicos
        builder.HasIndex(t => t.Telefone)
            .IsUnique()
            .HasDatabaseName("UQ_TBTutor_Telefone");

        builder.HasIndex(t => t.Cpf)
            .IsUnique()
            .HasDatabaseName("UQ_TBTutor_Cpf");
    }
}
