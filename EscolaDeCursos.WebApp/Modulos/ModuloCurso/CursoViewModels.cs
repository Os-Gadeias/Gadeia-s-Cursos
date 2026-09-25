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
    [Required(ErrorMessage = "The Name field is required.")]
    string Nome,
    [Required(ErrorMessage = "The Course Hours field is required.")]
    int CargaHoraria,
    [Required(ErrorMessage = "The Difficulty Level field is required.")]
    NivelDeDificildade Dificuldade,
    [Required(ErrorMessage = "The Category field is required.")]
    string CategoriaId
);
public record ExcluirCursoViewModel(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome
);
public record EditarCursoViewModel(
    string Id,
    [Required(ErrorMessage = "The Name field is required.")]
    string Nome,
    [Required(ErrorMessage = "The Course Hours field is required.")]
    int CargaHoraria,
    [Required(ErrorMessage = "The Difficulty Level field is required.")]
    NivelDeDificildade Dificuldade,
    [Required(ErrorMessage = "The Category field is required.")]
    string CategoriaId
);
public record VisualizarTurmaEAulasViewModel(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome,
    List<ListarAulasViewModel>? Aulas
);
public record ListarAulasViewModel(
    string Id,
    string Nome,
    int Duracao
);
