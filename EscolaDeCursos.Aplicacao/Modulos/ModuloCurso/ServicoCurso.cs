using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Diagnostics;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;
    private readonly IRepositorioCategoria repositorioCategoria;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoCurso(IRepositorioCurso repositorioCurso, IRepositorioCategoria repositorioCategoria, IRepositorioTurma repositorioTurma)
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioCategoria = repositorioCategoria;
        this.repositorioTurma = repositorioTurma;
    }

    public Result Cadastrar(CadastrarCursoDto dto)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(new Guid(dto.CategoriaId));

        if (categoria == null)
            return Result.Fail("Categoria não encotrada!");

        Curso novoCurso = new(dto.Nome, dto.CargaHoraria, dto.Dificuldade, categoria!);

        Result resultadoValidacao = ValidarEntidade(novoCurso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteCursoComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe uma Curso com esse Nome!");

        repositorioCurso.Cadastrar(novoCurso);

        return Result.Ok();
    }

    public Result Excluir(ExcluirCursoDto dto)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(new Guid(dto.Id));

        if (curso == null)
            return Result.Fail("Curso não encontrado!");

        if (ExisteCursoAtreladoATurma(curso.Id))
            return Result.Fail("Não é possível excluir um curso atrelado a Turma!");

        repositorioCurso.Excluir(new Guid(dto.Id));

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
    public VisualizarTurmaEAulasDto SelecionarTurmaEAulasPorId(string id)
    {
        Curso? c = repositorioCurso.SelecionarPorId(new Guid(id));

        return new VisualizarTurmaEAulasDto(c.Id.ToString(), c.Nome,
        c.CargaHoraria, c.Dificuldade, c.Categoria.Titulo,
        c.Aulas.Select(a => new ListarAulasDto(a.Id.ToString(), a.Nome, a.Duracao)).ToList()
        );
    }
    public DetalhesCursoDto SelecionarPorId(string id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(new Guid(id));

        if (curso == null)
            return new DetalhesCursoDto("", "", 0, NivelDeDificildade.Inicial, "");

        return new DetalhesCursoDto(curso.Id.ToString(), curso.Nome, curso.CargaHoraria, curso.Dificuldade, curso.Categoria.Titulo);
    }
    public DetalhesCursoECategoriaDto SelecionarCursoECategoria(string id)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(new Guid(id));

        if (curso == null)
            return new DetalhesCursoECategoriaDto("", "", 0, NivelDeDificildade.Inicial, "");

        return new DetalhesCursoECategoriaDto(curso.Id.ToString(), curso.Nome, curso.CargaHoraria, curso.Dificuldade, curso.Categoria.Id.ToString());
    }
    public bool ExisteCursoComMesmoNome(string nome, Guid? idIgnorado = null)
    {
        return repositorioCurso.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Nome, nome, StringComparison.OrdinalIgnoreCase));
    }

    public Result Editar(EditarCursoDto dto)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(new Guid(dto.CategoriaId));

        if (categoria == null)
            return Falha(nameof(dto.CategoriaId), "Categoria não encontrada!");

        Curso novoCurso = new(dto.Nome, dto.CargaHoraria, dto.Dificuldade, categoria!);

        Result resultadoValidacao = ValidarEntidade(novoCurso);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteCursoComMesmoNome(dto.Nome, new Guid(dto.Id)))
            return Falha(nameof(dto.Nome), "Já existe uma Curso com esse Nome!");

        repositorioCurso.Editar(new Guid(dto.Id), novoCurso);

        return Result.Ok();
    }
    private bool ExisteCursoAtreladoATurma(Guid id)
    {
        return repositorioTurma.SelecionarTodos().Any(t => t.Curso.Id == id);
    }
}
