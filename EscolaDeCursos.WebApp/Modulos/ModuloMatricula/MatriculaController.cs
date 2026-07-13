using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using EscolaDeCursos.WebApp.Modulos.ModuloTurma;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public class MatriculaController : Controller
{
    private readonly ServicoMatricula servicoMatricula;

    private readonly IMapper mapper;

    public MatriculaController(ServicoMatricula servicoMatricula, IMapper mapper)
    {
        this.servicoMatricula = servicoMatricula;
        this.mapper = mapper;
    }

    public ActionResult Visualizar(string id)
    {
        Result<VisualizarTurmaEMatriculaDto> resultado = servicoMatricula.SelecionarTurmaEMatriculasPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(TurmaController.Listar), "Turma", new { id });
        }

        VisualizarTurmaEMatriculaViewModel vm = mapper.Map<VisualizarTurmaEMatriculaViewModel>(resultado.Value);

        return View(vm);
    }
}
