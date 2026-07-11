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
            return View(vm);
        }

        return RedirectToAction(nameof(CursoController.Visualizar), "Curso", new { id = vm.Id });
    }
}
