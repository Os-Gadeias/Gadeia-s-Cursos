using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public class RepositorioCursoOrm(EscolaDeCursosDbContext dbContext) :
RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
    public override List<Curso> SelecionarTodos()
    {
        return registros.Include(c => c.Categoria).ToList();
    }
    public override Curso? SelecionarPorId(Guid idSelecionado)
    {
        return registros.Include(c => c.Categoria).Include(c => c.Aulas)
        .SingleOrDefault(c => c.Id == idSelecionado);
    }
}