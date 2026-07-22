using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTutor;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTutor;

public class TutorController : Controller
{
    private readonly ServicoTutor servicoTutor;
    private readonly IMapper mapper;
    public TutorController(ServicoTutor servicoTutor, IMapper mapper)
    {
        this.servicoTutor = servicoTutor;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<ListarTutorDto> Dtos = servicoTutor.SelecionarTodos();

        List<ListarTutorViewModel> vms = mapper.Map<List<ListarTutorViewModel>>(Dtos);

        return View(vms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarTutorViewMosel vm)
    {
        CadastrarTutorDto dto = mapper.Map<CadastrarTutorDto>(vm);

        Result result = servicoTutor.Cadastrar(dto);

        if (result.IsFailed)
        {
            ModelState.AddModelError(result);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Excluir(Guid id)
    {
        ListarTutorDto dto = servicoTutor.SelecionarPorId(id);

        ExcluirTutorViewModel vm = mapper.Map<ExcluirTutorViewModel>(dto);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirTutorViewModel vm)
    {
        ExcluirTutorDto dto = mapper.Map<ExcluirTutorDto>(vm);

        Result resultado = servicoTutor.Excluir(dto);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        ListarTutorDto dto = servicoTutor.SelecionarPorId(id);

        EditarTutorViewMosel vm = mapper.Map<EditarTutorViewMosel>(dto);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Editar(EditarTutorViewMosel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        EditarTutorDto dto = mapper.Map<EditarTutorDto>(vm);

        Result result = servicoTutor.Editar(dto);

        if (result.IsFailed)
        {
            ModelState.AddModelError(result);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
}
