using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos.ModuloMatricula;

public class RepostitorioMatriculaEmOrm(EscolaDeCursosDbContext dbContext)
: RepositorioBaseEmOrm<Matricula>(dbContext), IRepositorioMatricula
{
    // public override List<Matricula> SelecionarTodos()
    // {
    //     return registros.Include(m => m.Aluno).Include(m => m.Turma).ToList();
    // }
    public override Matricula? SelecionarPorId(Guid idSelecionado)
    {
        return registros.Include(m => m.Aluno).Include(m => m.Turma)
        .SingleOrDefault(c => c.Id == idSelecionado);
    }
}
