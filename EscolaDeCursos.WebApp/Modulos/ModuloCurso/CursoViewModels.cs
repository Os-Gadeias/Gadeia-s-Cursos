using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public record ListarCursoViewModel(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome
);
public record CadastrarCursoViewModel(
    [Required(ErrorMessage = "O campo \"Nome\" é obrigatório!")]
    string Nome,
    [Required(ErrorMessage = "O campo \"Carga Horaria\" é obrigatório!")]
    int CargaHoraria,
    [Required(ErrorMessage = "O campo \"Nível de Dificuldade\" é obrigatório!")]
    NivelDeDificildade Dificuldade,
    [Required(ErrorMessage = "O campo \"Categoria\" é obrigatório!")]
    string CategoriaId
);
public record ExcluirCursoViewModel(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome
);