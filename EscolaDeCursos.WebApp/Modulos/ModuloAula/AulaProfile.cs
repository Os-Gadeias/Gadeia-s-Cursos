using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAula;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;
using EscolaDeCursos.WebApp.Modulos.ModuloAula.Views;
using EscolaDeCursos.WebApp.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula;

public class AulaProfile : Profile
{
    public AulaProfile()
    {
        CreateMap<CadastrarAulaViewModel, CadastrarAulaDto>();
        CreateMap<ListarAulasDto, ListarAulasViewModel>();
    }
}
