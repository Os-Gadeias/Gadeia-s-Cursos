using AutoMapper;
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
}
