using System.Linq.Expressions;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

public sealed class RepositorioTutorEmOrm(EscolaDeCursosDbContext dbContext)
    : IRepositorioTutor
{

    public void Cadastrar(Tutor entidade)
    {
        dbContext.Add(entidade);

        dbContext.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Tutor entidadeAtualizada)
    {
        Tutor? tutorSelecionado = SelecionarPorId(idSelecionado);

        if (tutorSelecionado == null)
            return false;

        tutorSelecionado.Atualizar(entidadeAtualizada);

        dbContext.SaveChanges(); // isso e igual a um comit!!!

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Tutor? tutorSelecionado = SelecionarPorId(idSelecionado);

        if (tutorSelecionado == null)
            return false;

        dbContext.Tutores.Remove(tutorSelecionado);

        dbContext.SaveChanges();

        return true;
    }

    public Tutor? SelecionarPorId(Guid idSelecionado)
    {
        return dbContext.Tutores.SingleOrDefault(t => t.Id == idSelecionado);
    }

    public List<Tutor> SelecionarTodos()
    {
        return dbContext.Tutores.OrderBy(t => t.Nome).ToList();
    }

    public List<Tutor> Filtrar(Expression<Func<Tutor, bool>> filtro)
    {
        return dbContext.Tutores.Where(filtro).ToList();
    }
}
