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

        repositorioCategoria.Cadastrar(novaCategoria);

        return Result.Ok();
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
