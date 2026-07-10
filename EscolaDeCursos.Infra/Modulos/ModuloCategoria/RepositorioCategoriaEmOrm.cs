
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;
using Microsoft.EntityFrameworkCore;

namespace EscolaDeCursos.Infra.Modulos;

public class RepositorioCategoriaEmOrm(EscolaDeCursosDbContext dbContext) : IRepositorioCategoria
{
    private readonly EscolaDeCursosDbContext contexto = dbContext;
    private readonly DbSet<Categoria> registros = dbContext.Categorias;
    public void Cadastrar(Categoria entidade)
    {
        registros.Add(entidade);
        contexto.SaveChanges();
    }

    public bool Editar(Guid idSelecionado, Categoria entidadeAtualizada)
    {
        Categoria? categoriaSelecionada = SelecionarPorId(idSelecionado);

        if (categoriaSelecionada == null)
            return false;

        categoriaSelecionada.Atualizar(entidadeAtualizada);

        contexto.SaveChanges();

        return true;
    }

    public bool Excluir(Guid idSelecionado)
    {
        Categoria? categoria = SelecionarPorId(idSelecionado);

        if (categoria == null)
            return false;

        contexto.Remove(categoria);
        contexto.SaveChanges();

        return true;
    }

    public List<Categoria> Filtrar(Func<Categoria, bool> filtro)
    {
        return contexto.Categorias.Where(filtro).ToList();
    }

    public Categoria? SelecionarPorId(Guid idSelecionado)
    {
        return contexto.Categorias.SingleOrDefault(c => c.Id == idSelecionado);
    }

    public List<Categoria> SelecionarTodos()
    {
        return registros.OrderBy(e => e.Titulo).ToList();
    }
}