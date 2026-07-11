using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public class RepositorioCursoOrm(EscolaDeCursosDbContext dbContext) :
RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso
{
    public override List<Curso> SelecionarTodos()
    {
        //obriga a fazer um join no banco de categoria
        return registros.Include(c => c.Categoria).ToList();
    }
    public override Curso? SelecionarPorId(Guid idSelecionado)
    {
        return registros.Include(c => c.Categoria)
        .SingleOrDefault(c => c.Id == idSelecionado);
    }
}