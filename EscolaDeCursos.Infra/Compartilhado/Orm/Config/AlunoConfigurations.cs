using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EscolaDeCursos.Infra.Compartilhado.Orm.Config;

public class AlunoConfigurations : IEntityTypeConfiguration<Aluno>
{
    public void Configure(EntityTypeBuilder<Aluno> builder)
    {
        builder.ToTable("TBAluno");

        builder.HasKey(t => t.Id)
            .HasName("PK_TBAluno");

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
            .HasDatabaseName("UQ_TBAluno_Telefone");

        builder.HasIndex(t => t.Cpf)
            .IsUnique()
            .HasDatabaseName("UQ_TBAluno_Cpf");
    }
}
