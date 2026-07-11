using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public class CursoProfile : Profile
{
    public CursoProfile()
    {
        CreateMap<DetalhesCursoDto, ListarCursoViewModel>();
        CreateMap<CadastrarCursoViewModel, CadastrarCursoDto>();
    }
}
