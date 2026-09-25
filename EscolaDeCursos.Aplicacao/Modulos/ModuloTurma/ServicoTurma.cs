using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTutor;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;

public class ServicoTurma : ServicoBase<Turma>
{
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IRepositorioTutor repositorioTutor;
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoTurma(IRepositorioCurso repositorioCurso, IRepositorioTutor repositorioTutor, IRepositorioTurma repositorioTurma)
    {
        this.repositorioCurso = repositorioCurso;
        this.repositorioTutor = repositorioTutor;
        this.repositorioTurma = repositorioTurma;
    }

    public List<ListarTurmaDto> SelecionarTodos()
    {
        return repositorioTurma.SelecionarTodos().Select(t => new ListarTurmaDto(
            t.Id,
            t.Titulo,
            t.CapacidadeMaxima,
            t.DataInicio.ToShortDateString(),
            t.DataTermino.ToShortDateString(),
            t.Tutor.Nome,
            t.Curso.Nome
        )).ToList();
    }
    public Result<ListarTurmaDto> SelecionarPorId(string id)
    {
        Turma? t = repositorioTurma.SelecionarPorId(new Guid(id));

        if (t == null)
            return Result.Fail("Class not found.");

        return new ListarTurmaDto(t.Id, t.Titulo, t.CapacidadeMaxima, t.DataInicio.ToShortDateString(),
         t.DataTermino.ToShortDateString(),
          t.Tutor.Nome, t.Curso.Nome);
    }
    public List<SelectListItem> CarregarCursos()
    {
        return repositorioCurso.SelecionarTodos().Select(c => new SelectListItem(c.Nome, c.Id.ToString())).ToList();
    }
    public List<SelectListItem> CarregarTutores()
    {
        return repositorioTutor.SelecionarTodos().Select(c => new SelectListItem(c.Nome, c.Id.ToString())).ToList();
    }

    public Result Cadastrar(CadastrarTurmaDto dto)
    {
        Curso? cursoSelecionado = repositorioCurso.SelecionarPorId(dto.IdCurso);
        Tutor? tutorSelecionado = repositorioTutor.SelecionarPorId(dto.IdTutor);
        bool tituloJaExiste = repositorioTurma.Filtrar(t => t.Titulo == dto.Titulo).Any();

        if (tituloJaExiste)
            return Result.Fail("A class with this title already exists.");

        if (tutorSelecionado == null)
            return Result.Fail("The selected tutor does not exist.");

        if (cursoSelecionado == null)
            return Result.Fail("The selected course does not exist.");

        Turma novaTurma = new(dto.Titulo, dto.CapacidadeMaxima, dto.DataInicio, dto.DataTermino, tutorSelecionado, cursoSelecionado);
        Result resultadoValidacao = ValidarEntidade(novaTurma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTurma.Cadastrar(novaTurma);

        return Result.Ok();
    }

    public Result Editar(EditarTurmaDto dto)
    {
        Curso? cursoSelecionado = repositorioCurso.SelecionarPorId(dto.IdCurso);
        Tutor? tutorSelecionado = repositorioTutor.SelecionarPorId(dto.IdTutor);
        bool tituloJaExiste = repositorioTurma.Filtrar(t => t.Titulo == dto.Titulo && t.Id != dto.Id).Any();

        if (tituloJaExiste)
            return Result.Fail("A class with this title already exists.");

        if (tutorSelecionado == null)
            return Result.Fail("The selected tutor does not exist.");

        if (cursoSelecionado == null)
            return Result.Fail("The selected course does not exist.");

        Turma turmaAtualizada = new(dto.Titulo, dto.CapacidadeMaxima, dto.DataInicio, dto.DataTermino, tutorSelecionado, cursoSelecionado);
        Turma novaTurma = new(dto.Titulo, dto.CapacidadeMaxima, dto.DataInicio, dto.DataTermino, tutorSelecionado, cursoSelecionado);

        Result resultadoValidacao = ValidarEntidade(novaTurma);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        repositorioTurma.Editar(dto.Id, turmaAtualizada);

        return Result.Ok();
    }
    public Result Excluir(ExcluirTurmaDto dto)
    {
        Turma? turmaSelecionada = repositorioTurma.SelecionarPorId(dto.Id);

        if (turmaSelecionada == null)
            return Result.Fail("Class not found.");

        repositorioTurma.Excluir(dto.Id);

        return Result.Ok();
    }
    public Result<EditarTurmaDto> SelecionarPorIdEditavel(string id)
    {
        Turma? t = repositorioTurma.SelecionarPorId(new Guid(id));

        if (t == null)
            return Result.Fail("Class not found.");

        return new EditarTurmaDto(t.Id, t.Titulo, t.CapacidadeMaxima, t.DataInicio,
         t.DataTermino,
          t.Tutor.Id, t.Curso.Id);
    }

}
