using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoController : Controller
{
    public readonly ServicoCurso servicoCurso;
    public readonly IMapper mapper;

    public CursoController(ServicoCurso servicoCurso, IMapper mapper)
    {
        this.servicoCurso = servicoCurso;
        this.mapper = mapper;
    }

    public ActionResult Listar()
    {
        List<DetalhesCursoDto> dtos = servicoCurso.SelecionarTodos();

        List<ListarCursoViewModel> vms = mapper.Map<List<ListarCursoViewModel>>(dtos);

        return View(vms);
    }
}
