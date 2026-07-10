using AutoMapper;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public class CategoriaProfile : Profile
{
    public CategoriaProfile()
    {
        CreateMap<DetalhesCategoriaDto, ListarCategoriaViewModel>();
        CreateMap<DetalhesCategoriaDto, EditarCategoriaViewModel>();
        CreateMap<CadastrarCategoriaViewModel, CadastrarCategoriaDto>();
        CreateMap<DetalhesCategoriaDto, ExcluirCategoriaViewModel>();
        CreateMap<ExcluirCategoriaViewModel, ExcluirCategoriaDto>();
        CreateMap<EditarCategoriaViewModel, EditarCategoriaDto>();
    }
}
