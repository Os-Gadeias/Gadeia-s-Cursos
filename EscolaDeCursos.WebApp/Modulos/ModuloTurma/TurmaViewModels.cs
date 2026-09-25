using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public record ListarTurmaViewModel(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    string DataInicio,
    string DataTermino,
    string NomeTutor,
    string NomeCurso
);
public record EditarTurmaViewModel(
    string Id,
    [Required(ErrorMessage = "The Title field is required.")]
    string Titulo,
    [Required(ErrorMessage = "The Maximum Capacity field is required.")]
    int CapacidadeMaxima,
    [Required(ErrorMessage = "The Start Date field is required.")]
    DateTime DataInicio,
    [Required(ErrorMessage = "The End Date field is required.")]
    DateTime DataTermino,
    [Required(ErrorMessage = "The Tutor field is required.")]
    Guid IdTutor,
    [Required(ErrorMessage = "The Course field is required.")]
    Guid IdCurso
);

public record CadastrarTurmaViewModel(
    [Required(ErrorMessage = "The Title field is required.")]
    string Titulo,
    [Required(ErrorMessage = "The Maximum Capacity field is required.")]
    int CapacidadeMaxima,
    [Required(ErrorMessage = "The Start Date field is required.")]
    DateTime DataInicio,
    [Required(ErrorMessage = "The End Date field is required.")]
    DateTime DataTermino,
    [Required(ErrorMessage = "The Tutor field is required.")]
    Guid IdTutor,
    [Required(ErrorMessage = "The Course field is required.")]
    Guid IdCurso
);

public record ExcluirTurmaViewModel(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    string DataInicio,
    string DataTermino,
    string NomeTutor,
    string NomeCurso
);
