namespace EscolaDeCursos.WebApp.Modulos.ModuloTurma;

public record ListarTurmaViewModel(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    string NomeTutor,
    string NomeCurso
);

public record EditarTurmaViewModel(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    Guid IdTutor,
    Guid IdCurso
);

public record CadastrarTurmaViewModel(
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    Guid IdTutor,
    Guid IdCurso
);

public record ExcluirTurmaViewModel(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    Guid IdTutor,
    Guid IdCurso
);
