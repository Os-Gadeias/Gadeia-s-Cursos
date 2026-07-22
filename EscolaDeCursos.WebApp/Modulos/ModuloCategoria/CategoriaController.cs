using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IMapper mapper;

    public CategoriaController(ServicoCategoria servicoCategoria, IMapper mapper)
    {
        this.servicoCategoria = servicoCategoria;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<DetalhesCategoriaDto> dtos = servicoCategoria.SelecionarTodos();

        List<ListarCategoriaViewModel> vms = mapper.Map<List<ListarCategoriaViewModel>>(dtos);

        return View(vms);
    }
    public ActionResult Cadastrar()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarCategoriaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        CadastrarCategoriaDto dto = mapper.Map<CadastrarCategoriaDto>(vm);

        Result resultado = servicoCategoria.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Excluir(string id)
    {
        DetalhesCategoriaDto dto = servicoCategoria.SelecionarPorId(id);

        ExcluirCategoriaViewModel vm = mapper.Map<ExcluirCategoriaViewModel>(dto);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirCategoriaViewModel vm)
    {
        ExcluirCategoriaDto dto = mapper.Map<ExcluirCategoriaDto>(vm);

        Result resultado = servicoCategoria.Excluir(dto);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Editar(string id)
    {
        DetalhesCategoriaDto dto = servicoCategoria.SelecionarPorId(id);

        EditarCategoriaViewModel vm = mapper.Map<EditarCategoriaViewModel>(dto);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Editar(EditarCategoriaViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        EditarCategoriaDto dto = mapper.Map<EditarCategoriaDto>(vm);

        Result resultado = servicoCategoria.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
}
