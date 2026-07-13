using AutoMapper;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public class TurmaProfile : Profile
{
    public TurmaProfile()
    {
        CreateMap<ListarTurmaDto, ListarTurmaViewModel>();
        CreateMap<CadastrarTurmaViewModel, CadastrarTurmaDto>();
        CreateMap<ListarTurmaDto, ExcluirTurmaViewModel>();
        CreateMap<ExcluirTurmaViewModel, ExcluirTurmaDto>();
    }
}
