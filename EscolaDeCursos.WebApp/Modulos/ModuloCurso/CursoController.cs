using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoController : Controller
{
    public readonly ServicoCurso servicoCurso;
    public readonly ServicoCategoria servicoCategoria;
    public readonly IMapper mapper;

    public CursoController(ServicoCurso servicoCurso, IMapper mapper, ServicoCategoria servicoCategoria)
    {
        this.servicoCurso = servicoCurso;
        this.mapper = mapper;
        this.servicoCategoria = servicoCategoria;
    }

    public ActionResult Listar()
    {
        List<DetalhesCursoDto> dtos = servicoCurso.SelecionarTodos();

        List<ListarCursoViewModel> vms = mapper.Map<List<ListarCursoViewModel>>(dtos);

        return View(vms);
    }
    public ActionResult Cadastrar()
    {
        ViewBag.Categorias = servicoCategoria.SelecionarTodos()
        .Select(e => new SelectListItem(
            e.Titulo,
            e.Id.ToString()
        )).ToList();

        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarCursoViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = servicoCategoria.SelecionarTodos()
                .Select(e => new SelectListItem(
                e.Titulo,
                e.Id.ToString()
                )).ToList();

            return View(vm);
        }

        CadastrarCursoDto dto = mapper.Map<CadastrarCursoDto>(vm);

        Result resultado = servicoCurso.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            ViewBag.Categorias = servicoCategoria.SelecionarTodos()
                .Select(e => new SelectListItem(
                e.Titulo,
                e.Id.ToString()
                )).ToList();
            return View(vm);
        }
        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Excluir(string id)
    {
        DetalhesCursoDto dto = servicoCurso.SelecionarPorId(id);

        ExcluirCursoViewModel vm = mapper.Map<ExcluirCursoViewModel>(dto);

        return View(vm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirCursoViewModel vm)
    {
        ExcluirCursoDto dto = mapper.Map<ExcluirCursoDto>(vm);

        Result resultado = servicoCurso.Excluir(dto);

        if (resultado.IsFailed)
            TempData.AddErrorMessage(resultado);

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Editar(string id)
    {
        DetalhesCursoECategoriaDto dto = servicoCurso.SelecionarCursoECategoria(id);

        EditarCursoViewModel vm = mapper.Map<EditarCursoViewModel>(dto);

        ViewBag.Categorias = servicoCategoria.SelecionarTodos()
                .Select(e => new SelectListItem(
                e.Titulo,
                e.Id.ToString()
                )).ToList();

        return View(vm);
    }
    [HttpPost]
    public ActionResult Editar(EditarCursoViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            ViewBag.Categorias = servicoCategoria.SelecionarTodos()
                .Select(e => new SelectListItem(
                e.Titulo,
                e.Id.ToString()
                )).ToList();

            return View(vm);
        }

        EditarCursoDto dto = mapper.Map<EditarCursoDto>(vm);

        Result resultado = servicoCurso.Editar(dto);

        if (resultado.IsFailed)
        {
            ModelState.AddModelError(resultado);
            ViewBag.Categorias = servicoCategoria.SelecionarTodos()
                .Select(e => new SelectListItem(
                e.Titulo,
                e.Id.ToString()
                )).ToList();
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Visualizar(string id)
    {
        VisualizarTurmaEAulasDto dto = servicoCurso.SelecionarTurmaEAulasPorId(id);

        VisualizarTurmaEAulasViewModel vm = mapper.Map<VisualizarTurmaEAulasViewModel>(dto);

        return View(vm);
    }
}
