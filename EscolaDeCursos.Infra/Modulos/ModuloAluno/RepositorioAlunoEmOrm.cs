
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloAluno
{
    public class RepositorioAlunoEmOrm(EscolaDeCursosDbContext dbContext)
    : RepositorioBaseEmOrm<Aluno>(dbContext), IRepositorioAluno;
}