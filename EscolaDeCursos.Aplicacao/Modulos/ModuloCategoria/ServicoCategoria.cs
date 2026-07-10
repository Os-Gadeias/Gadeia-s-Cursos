using Azure;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using FluentResults;
using Microsoft.AspNetCore.Http.HttpResults;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public sealed class ServicoCategoria : ServicoBase<Categoria>
{
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCategoria(IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCategoria = repositorioCategoria;
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

    public void Excluir(ExcluirCategoriaDto dto)
    {
        Categoria? c = repositorioCategoria.SelecionarPorId(new Guid(dto.Id));

        if (c == null)
            throw new Exception("Categoria não encontrada!");

        repositorioCategoria.Excluir(new Guid(dto.Id));
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
    public bool ExisteCategoriaComMesmoNome(string titulo, Guid? idIgnorado = null)
    {
        return repositorioCategoria.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Titulo, titulo, StringComparison.OrdinalIgnoreCase));
    }
}
