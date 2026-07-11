using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloAula;

public class RepositorioAulaEmOrm(EscolaDeCursosDbContext dbContext)
    : RepositorioBaseEmOrm<Aula>(dbContext), IRepositorioAula
{
    public override Aula? SelecionarPorId(Guid idSelecionado)
    {
        return registros.Include(c => c.Curso)
        .SingleOrDefault(c => c.Id == idSelecionado);
    }
}