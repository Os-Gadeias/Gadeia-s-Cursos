using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public class ServicoMatricula : ServicoBase<Matricula>
{
    private readonly IRepositorioMatricula repositorioMatricula;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoMatricula(IRepositorioMatricula repositorioMatricula, IRepositorioTurma repositorioTurma)
    {
        this.repositorioMatricula = repositorioMatricula;
        this.repositorioTurma = repositorioTurma;
    }

    public Result<VisualizarTurmaEMatriculaDto> SelecionarTurmaEMatriculasPorId(string id)
    {
        Turma? m = repositorioTurma.SelecionarPorId(new Guid(id));

        if (m == null)
            return Result.Fail("Turma e Matriculas não encontrada!");

        return new VisualizarTurmaEMatriculaDto(m.Id, m.Titulo, m.CapacidadeMaxima, m.DataInicio.ToShortDateString(),
        m.DataTermino.ToShortDateString(), m.Tutor.Nome, m.Curso.Nome,
        m.Matriculas.Select(e => new ListarMatriculaDto(e.Id.ToString(), e.Aluno.Id.ToString(), e.EstaAtiva)).ToList()
        );
    }
}
