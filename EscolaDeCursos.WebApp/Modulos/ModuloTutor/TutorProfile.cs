using AutoMapper;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTutor;

public class TutorProfile : Profile
{
    public TutorProfile()
    {
        CreateMap<ListarTutorDto, ListarTutorViewModel>();
    }
}
