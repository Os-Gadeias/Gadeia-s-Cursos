using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAula.Views;

public record CadastrarAulaViewModel(
    string Id,
    [Required(ErrorMessage ="O campo \"Nome\" é obrigatório!")]
    string Nome,
    [Range(20, int.MaxValue, ErrorMessage = "A duração deve ser no mínimo que 20 horas!")]
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
    [Required(ErrorMessage ="O campo \"Nome\" é obrigatório!")]
    string Nome,
    [Range(20, int.MaxValue, ErrorMessage = "A duração deve ser no mínimo que 20 horas!")]
    int Duracao,
    string IdCurso
);