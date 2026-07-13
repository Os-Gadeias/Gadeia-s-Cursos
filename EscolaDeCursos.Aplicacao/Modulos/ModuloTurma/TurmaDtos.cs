
public record ListarTurmaDto(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    string NomeTutor,
    string NomeCurso
);

public record EditarTurmaDto(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    Guid IdTutor,
    Guid IdCureso
);

public record CadastrarTurmaDto(
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    Guid IdTutor,
    Guid IdCureso
);

public record ExcluirTurmaDto(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    DateTime DataInicio,
    DateTime DataTermino,
    Guid IdTutor,
    Guid IdCureso
);
