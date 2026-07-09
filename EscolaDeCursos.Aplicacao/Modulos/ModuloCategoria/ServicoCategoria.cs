using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public sealed class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
    }

    public List<DetalhesCategoriaDto> SelecionarTodos()
    {
        return repositorioCategoria.SelecionarTodos().Select(e => new DetalhesCategoriaDto(
            e.Id.ToString(),
            e.Titulo,
            e.Cor,
            e.Icon
        )).ToList();
    }
}
