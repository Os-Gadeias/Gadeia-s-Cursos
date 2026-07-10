using AutoMapper;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTutor;

public class TutorProfile : Profile
{
    public TutorProfile()
    {
        CreateMap<ListarTutorDto, ListarTutorViewModel>();
        CreateMap<ListarTutorDto, EditarTutorViewMosel>();
        CreateMap<CadastrarTutorViewMosel, CadastrarTutorDto>();
        CreateMap<ListarTutorDto, ExcluirTutorViewModel>();
        CreateMap<ExcluirTutorViewModel, ExcluirTutorDto>();
        CreateMap<EditarTutorViewMosel, EditarTutorDto>();
    }
}
