using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public class MatriculaProfile : Profile
{
    public MatriculaProfile()
    {
        CreateMap<VisualizarTurmaEMatriculaDto, VisualizarTurmaEMatriculaViewModel>();
        CreateMap<CadastrarMatriculaViewModel, CadastrarMatriculaDto>();
        CreateMap<ListarMatriculaDto, ListarMatriculaViewModel>();
    }
}
