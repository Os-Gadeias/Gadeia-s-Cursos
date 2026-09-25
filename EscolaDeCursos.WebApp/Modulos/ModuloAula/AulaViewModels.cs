using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula.Views;

public record CadastrarAulaViewModel(
    string Id,
    [Required(ErrorMessage = "The Name field is required.")]
    string Nome,
    [Range(20, int.MaxValue, ErrorMessage = "Duration must be at least 20 hours.")]
    int Duracao
);
public record ExcluirAulaViewModel(
    string Id,
    string Nome,
    int Duracao,
    string IdCurso
);
public record EditarAulaViewModel(
    string Id,
    [Required(ErrorMessage = "The Name field is required.")]
    string Nome,
    [Range(20, int.MaxValue, ErrorMessage = "Duration must be at least 20 hours.")]
    int Duracao,
    string IdCurso
);