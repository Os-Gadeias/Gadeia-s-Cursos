using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using EscolaDeCursos.WebApp.Modulos.ModuloTurma;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

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
    public ActionResult CadastrarMatricula(string id)
    {
        CadastrarMatriculaViewModel vm = new(id, "");

        ViewBag.Alunos = servicoMatricula.CarregarAlunos();

        return View(vm);
    }
    [HttpPost]
    public ActionResult CadastrarMatricula(CadastrarMatriculaViewModel vm)
    {
        CadastrarMatriculaDto dto = mapper.Map<CadastrarMatriculaDto>(vm);

        Result resultado = servicoMatricula.Matricular(dto);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Visualizar), new { vm.Id });
    }
    [HttpPost]
    public ActionResult ExcluirMatricula(string id, string idMatricula)
    {
        Result resultado = servicoMatricula.ExcluirMatricula(idMatricula);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);
        else
            TempData.AddSucessMessage("Matricula Excluida com sucesso!");

        return RedirectToAction(nameof(Visualizar), new { id });
    }
}
