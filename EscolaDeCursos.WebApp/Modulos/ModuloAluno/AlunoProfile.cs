using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria.ModuloAluno;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<ListarAlunoDto, ListarAlunoViewModel>();
        CreateMap<ListarAlunoDto, EditarAlunoViewModel>();
        CreateMap<CadastrarAlunoViewModel, CadastrarAlunoDto>();
        CreateMap<ListarAlunoDto, ExcluirAlunoViewModel>();
        CreateMap<ExcluirAlunoViewModel, ExcluirAlunoDto>();
        CreateMap<EditarAlunoViewModel, EditarAlunoDto>();
    }
}
