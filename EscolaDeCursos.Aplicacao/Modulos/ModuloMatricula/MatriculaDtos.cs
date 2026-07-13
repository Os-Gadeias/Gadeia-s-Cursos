namespace EscolaDeCursos.Aplicacao.Modulos.ModuloMatricula;

public record VisualizarTurmaEMatriculaDto(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    string DataInicio,
    string DataTermino,
    string NomeTutor,
    string NomeCurso,
    List<ListarMatriculaDto>? Matriculas
);
public record ListarMatriculaDto(
    string Id,
    string NomeAluno,
    bool EstaAtiva
);
