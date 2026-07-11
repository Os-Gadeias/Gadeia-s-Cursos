using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioCategoria repositorioCategoria;

    public ServicoCurso(IRepositorioCurso repositorioCurso, IRepositorioCategoria repositorioCategoria)
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioCategoria = repositorioCategoria;
    }

    public Result Cadastrar(CadastrarCursoDto dto)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(new Guid(dto.CategoriaId));

        Curso novoCurso = new(dto.Nome, dto.CargaHoraria, dto.Dificuldade, categoria!);

        Result resultadoValidacao = ValidarEntidade(novoCurso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteCursoComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe uma Curso com esse Nome!");

        repositorioCurso.Cadastrar(novoCurso);

        return Result.Ok();
    }

    public List<DetalhesCursoDto> SelecionarTodos()
    {
        return repositorioCurso.SelecionarTodos().Select(c => new DetalhesCursoDto(
            c.Id.ToString(),
            c.Nome,
            c.CargaHoraria,
            c.Dificuldade,
            c.Categoria.Titulo
        )).ToList();
    }
    public DetalhesCursoDto SelecionarPorId(string id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(new Guid(id));

        if (curso == null)
            return new DetalhesCursoDto("", "", 0, NivelDeDificildade.Inicial, "");

        return new DetalhesCursoDto(curso.Id.ToString(), curso.Nome, curso.CargaHoraria, curso.Dificuldade, curso.Categoria.Titulo);
    }
    public bool ExisteCursoComMesmoNome(string nome, Guid? idIgnorado = null)
    {
        return repositorioCurso.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Nome, nome, StringComparison.OrdinalIgnoreCase));
    }
}
