using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using FluentResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public sealed class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria, IRepositorioCurso repositorioCurso)
    {
        this.repositorioCategoria = repositorioCategoria;
        this.repositorioCurso = repositorioCurso;
    }

    public Result Cadastrar(CadastrarCategoriaDto dto)
    {
        Categoria novaCategoria = new(dto.Icon, dto.Titulo, dto.Cor);

        Result resultadoValidacao = ValidarEntidade(novaCategoria);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteCategoriaComMesmoNome(dto.Titulo))
            return Falha(nameof(dto.Titulo), "Já existe uma categoria com esse Titulo!");

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
    }

    public Result Editar(EditarCategoriaDto dto)
    {
        Categoria catedogoriaEditada = new(dto.Icon, dto.Titulo, dto.Cor);

        Result resultadoValidacao = ValidarEntidade(catedogoriaEditada);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteCategoriaComMesmoNome(dto.Titulo, new Guid(dto.Id)))
            return Falha(nameof(dto.Titulo), "Já existe uma categoria com esse Titulo!");

        repositorioCategoria.Editar(new Guid(dto.Id), catedogoriaEditada);

        return Result.Ok();
    }

    public Result Excluir(ExcluirCategoriaDto dto)
    {
        Categoria? c = repositorioCategoria.SelecionarPorId(new Guid(dto.Id));

        if (c == null)
            return Result.Fail("Categoria não encontrada!");

        if (ExisteCategoriaAtreladaACurso(c.Id))
            return Result.Fail("Não é possível excluir uma categoria com atrelada a um Curso!");

        repositorioCategoria.Excluir(new Guid(dto.Id));

        return Result.Ok();
    }

    public DetalhesCategoriaDto SelecionarPorId(string id)
    {
        Categoria? c = repositorioCategoria.SelecionarPorId(new Guid(id));

        if (c == null)
            throw new Exception("Categoria não encontrada!");

        return new DetalhesCategoriaDto(c.Id.ToString(), c.Titulo, c.Cor, c.Icon);
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
    private bool ExisteCategoriaComMesmoNome(string titulo, Guid? idIgnorado = null)
    {
        return repositorioCategoria.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
    }

    private bool ExisteCategoriaAtreladaACurso(Guid id)
    {
        return repositorioCurso.SelecionarTodos().Any(c => c.Categoria.Id == id);
    }

}
