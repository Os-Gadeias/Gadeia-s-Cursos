using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using EscolaDeCursos.WebApp.Compartilhado.Extensions;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria.ModuloAluno;
//six seven
public class AlunoController : Controller
{
    private readonly ServicoAluno servicoAluno;
    private readonly IMapper mapper;
    public AlunoController(ServicoAluno servicoAluno, IMapper mapper)
    {
        this.servicoAluno = servicoAluno;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<ListarAlunoDto> dtos = servicoAluno.SelecionarTodos();

        List<ListarAlunoViewModel> vms = mapper.Map<List<ListarAlunoViewModel>>(dtos);

        return View(vms);
    }

    [HttpGet]
    public ActionResult Cadastrar()
    {
        return View();
    }

    [HttpPost]
    public ActionResult Cadastrar(CadastrarAlunoViewModel vm)
    {
        CadastrarAlunoDto dto = mapper.Map<CadastrarAlunoDto>(vm);

        Result result = servicoAluno.Cadastrar(dto);

        if (result.IsFailed)
        {
            ModelState.AddModelError(result);
            return View(vm);
        }

        return RedirectToAction(nameof(Listar));
    }

    [HttpGet]
    public ActionResult Editar(Guid id)
    {
        ListarAlunoDto? dto = servicoAluno.SelecionarPorId(id);

        EditarAlunoViewModel vm = mapper.Map<EditarAlunoViewModel>(dto);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Editar(EditarAlunoViewModel vm)
    {
        if (!ModelState.IsValid)
            return View(vm);

        EditarAlunoDto dto = mapper.Map<EditarAlunoDto>(vm);

        Result result = servicoAluno.Editar(dto);

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
        ListarAlunoDto dto = servicoAluno.SelecionarPorId(id);

        ExcluirAlunoViewModel vm = mapper.Map<ExcluirAlunoViewModel>(dto);

        return View(vm);
    }

    [HttpPost]
    public ActionResult Excluir(ExcluirAlunoViewModel vm)
    {
        ExcluirAlunoDto dto = mapper.Map<ExcluirAlunoDto>(vm);

        servicoAluno.Excluir(dto);

        return RedirectToAction(nameof(Listar));
    }
}
