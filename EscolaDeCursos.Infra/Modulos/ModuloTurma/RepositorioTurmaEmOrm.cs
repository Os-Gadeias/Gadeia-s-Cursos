using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloTurma;

public class RepositorioTurmaEmOrm(EscolaDeCursosDbContext dbContext)
 : RepositorioBaseEmOrm<Turma>(dbContext), IRepositorioTurma
{
    public override List<Turma> SelecionarTodos()
    {
        return registros.Include(t => t.Curso).Include(t => t.Tutor).ToList();
    }
    public override Turma? SelecionarPorId(Guid idSelecionado)
    {
        return registros.Include(t => t.Curso).Include(t => t.Tutor)
        .SingleOrDefault(c => c.Id == idSelecionado);
    }
}
