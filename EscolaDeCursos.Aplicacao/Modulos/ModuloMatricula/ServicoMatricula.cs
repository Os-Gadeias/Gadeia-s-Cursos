using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioTurma repositorioTurma;
    private readonly IRepositorioAluno repositorioAluno;

    public ServicoMatricula(IRepositorioMatricula repositorioMatricula, IRepositorioTurma repositorioTurma, IRepositorioAluno repositorioAluno)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioTurma = repositorioTurma;
        this.repositorioAluno = repositorioAluno;
    }

    public Result<VisualizarTurmaEMatriculaDto> SelecionarTurmaEMatriculasPorId(string id)
    {
        Turma? m = repositorioTurma.SelecionarPorId(new Guid(id));

        if (m == null)
            return Result.Fail("Class not found.");

        return new VisualizarTurmaEMatriculaDto(m.Id, m.Titulo, m.CapacidadeMaxima, m.DataInicio.ToShortDateString(),
        m.DataTermino.ToShortDateString(), m.Tutor.Nome, m.Curso.Nome,
        m.Matriculas.Select(e => new ListarMatriculaDto(e.Id.ToString(), e.Aluno.Nome, e.EstaAtiva)).ToList()
        );
    }
    public List<SelectListItem> CarregarAlunos()
    {
        return repositorioAluno.SelecionarTodos().Select(a => new SelectListItem(a.Nome, a.Id.ToString())).ToList();
    }

    public Result Matricular(CadastrarMatriculaDto dto)
    {
        Turma? turma = repositorioTurma.SelecionarPorId(new Guid(dto.Id));

        Aluno? aluno = repositorioAluno.SelecionarPorId(new Guid(dto.IdAluno));

        bool alunoEstaMatriculado = repositorioTurma.SelecionarTodos()
            .Any(t => t.Matriculas.Any(m => m.Aluno.Id == new Guid(dto.IdAluno)));

        if (alunoEstaMatriculado)
            return Result.Fail("The student is already enrolled in this class.");

        if (turma == null)
            return Result.Fail("Class not found.");

        if (aluno == null)
            return Result.Fail("Student not found.");

        if (turma.Matriculas.Count + 1 > turma.CapacidadeMaxima)
            return Result.Fail("The class has reached its maximum student capacity.");

        Matricula matricula = new(aluno, turma);

        repositorioMatricula.Cadastrar(matricula);

        return Result.Ok();
    }
    public Result ExcluirMatricula(string id)
    {
        Matricula? matricula = repositorioMatricula.SelecionarPorId(new Guid(id));

        if (matricula == null)
            return Result.Fail("Enrollment not found.");

        repositorioMatricula.Excluir(new Guid(id));

        return Result.Ok();
    }
}
