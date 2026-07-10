using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloTutor;
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
}
