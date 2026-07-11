using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;
using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria.ModuloAluno;

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

    [HttpPost]
    public ActionResult Cadastrar()
    {
        return View();
    }


}
