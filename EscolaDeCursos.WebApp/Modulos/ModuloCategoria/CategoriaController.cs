using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
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
}
