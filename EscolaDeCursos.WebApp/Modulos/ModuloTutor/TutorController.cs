using Microsoft.AspNetCore.Mvc;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTutor;

public class TutorController : Controller
{
    public ActionResult Listar()
    {
        ListarTutorViewModel vm = new ListarTutorViewModel(Guid.CreateVersion7(), "vitu", "(49) 989091739", "12345678901234");

        List<ListarTutorViewModel> listatutor = new List<ListarTutorViewModel>();

        listatutor.Add(vm);

        return View(listatutor);
    }
}
