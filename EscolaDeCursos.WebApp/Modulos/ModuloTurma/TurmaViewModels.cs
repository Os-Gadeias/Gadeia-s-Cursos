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
   [Required(ErrorMessage = "O campo \"Titulo\" é obrigatório!")]
    string Titulo,
    [Required(ErrorMessage = "O campo \"Capacidade Máxima\" é obrigatório!")]
    int CapacidadeMaxima,
    [Required(ErrorMessage = "O campo \"Data de Inicio\" é obrigatório!")]
    DateTime DataInicio,
    [Required(ErrorMessage = "O campo \"Data de Terminio\" é obrigatório!")]
    DateTime DataTermino,
    [Required(ErrorMessage = "O campo \"Tutor\" é obrigatório!")]
    Guid IdTutor,
    [Required(ErrorMessage = "O campo \"Curso\" é obrigatório!")]
    Guid IdCurso
);

public record CadastrarTurmaViewModel(
    [Required(ErrorMessage = "O campo \"Titulo\" é obrigatório!")]
    string Titulo,
    [Required(ErrorMessage = "O campo \"Capacidade Máxima\" é obrigatório!")]
    int CapacidadeMaxima,
    [Required(ErrorMessage = "O campo \"Data de Inicio\" é obrigatório!")]
    DateTime DataInicio,
    [Required(ErrorMessage = "O campo \"Data de Terminio\" é obrigatório!")]
    DateTime DataTermino,
    [Required(ErrorMessage = "O campo \"Tutor\" é obrigatório!")]
    Guid IdTutor,
    [Required(ErrorMessage = "O campo \"Curso\" é obrigatório!")]
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
