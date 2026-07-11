using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using EscolaDeCursos.WebApp.Modulos.ModuloAula.Views;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula;

public class AulaController : Controller
{
    public readonly ServicoAula servicoAula;
    public readonly IMapper mapper;

    public AulaController(ServicoAula servicoAula, IMapper mapper)
    {
        this.servicoAula = servicoAula;
        this.mapper = mapper;
    }

    public ActionResult CadastrarAula(string id)
    {
        CadastrarAulaViewModel vm = new(id, "", 0);

        return View(vm);
    }
    [HttpPost]
    public ActionResult CadastrarAula(CadastrarAulaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        CadastrarAulaDto dto = mapper.Map<CadastrarAulaDto>(vm);

        Result resultado = servicoAula.AdicionarAula(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(CursoController.Visualizar), "Curso", new { id = vm.Id });
        }
        else
            TempData.AddSucessMessage("Aula Cadastrada com sucesso!");

        return RedirectToAction(nameof(CursoController.Visualizar), "Curso", new { id = vm.Id });
    }
    public ActionResult ExcluirMatricula(string id)
    {
        Result<DetalhesAulaDto> dto = servicoAula.SelecionarPorId(id);

        if (dto.IsFailed)
        {
            TempData.AddErrorMessage(dto);
            return RedirectToAction(nameof(CursoController.Visualizar), "Curso", new { id });
        }

        ExcluirAulaViewModel vm = mapper.Map<ExcluirAulaViewModel>(dto.Value);

        return View(vm);
    }
    [HttpPost]
    public ActionResult ExcluirMatricula(ExcluirAulaViewModel vm)
    {
        ExcluirAulaDto dto = mapper.Map<ExcluirAulaDto>(vm);

        Result resultado = servicoAula.ExcluirMatricula(dto);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
        }
        else
            TempData.AddSucessMessage("Aula excluida com sucesso!");

        return RedirectToAction(nameof(CursoController.Visualizar), "Curso", new { id = vm.IdCurso });
    }
}
