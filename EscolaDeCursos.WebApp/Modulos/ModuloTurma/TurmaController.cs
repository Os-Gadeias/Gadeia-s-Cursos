using AutoMapper;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaController : Controller
{
    public readonly ServicoTurma servicoTurma;
    public readonly IMapper mapper;

    public TurmaController(ServicoTurma servicoTurma, IMapper mapper)
    {
        this.servicoTurma = servicoTurma;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<ListarTurmaDto> dtos = servicoTurma.SelecionarTodos();

        List<ListarTurmaViewModel> vms = mapper.Map<List<ListarTurmaViewModel>>(dtos);

        return View(vms);
    }
    public ActionResult Cadastrar()
    {
        ViewBag.Cursos = servicoTurma.CarregarCursos();
        ViewBag.Tutores = servicoTurma.CarregarTutores();

        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarTurmaViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Cursos = servicoTurma.CarregarCursos();
            ViewBag.Tutores = servicoTurma.CarregarTutores();
            return View();
        }

        CadastrarTurmaDto dto = mapper.Map<CadastrarTurmaDto>(vm);

        Result resultado = servicoTurma.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View();
        }

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Excluir(string id)
    {
        Result<ListarTurmaDto> resultado = servicoTurma.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            TempData.AddErrorMessage(resultado);
            return RedirectToAction(nameof(Listar));
        }

        ExcluirTurmaViewModel vm = mapper.Map<ExcluirTurmaViewModel>(resultado.Value);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirTurmaViewModel vm)
    {
        ExcluirTurmaDto dto = mapper.Map<ExcluirTurmaDto>(vm);

        Result resultado = servicoTurma.Excluir(dto);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
}
