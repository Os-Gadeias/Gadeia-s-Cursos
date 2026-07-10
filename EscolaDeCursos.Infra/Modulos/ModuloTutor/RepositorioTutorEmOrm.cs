using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

public sealed class RepositorioTutorEmOrm(EscolaDeCursosDbContext dbContext)
    : IRepositorioTutor
{
    private readonly EscolaDeCursosDbContext dbContext = dbContext;
    private readonly DbSet<Tutor> registros = dbContext.Tutores;

    public void Cadastrar(Tutor entidade)
    {
        registros.Add(entidade);

        this.dbContext.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Tutor entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public bool Excluir(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Tutor> Filtrar(Func<Tutor, bool> filtro)
    {
        throw new NotImplementedException();
    }

    public Tutor? SelecionarPorId(Guid idSelecionado)
    {
        throw new NotImplementedException();
    }

    public List<Tutor> SelecionarTodos()
    {
        return registros.OrderBy(t => t.Nome).ToList();
    }
}
