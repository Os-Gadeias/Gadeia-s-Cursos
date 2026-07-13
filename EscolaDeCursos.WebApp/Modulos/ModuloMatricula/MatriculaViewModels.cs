namespace EscolaDeCursos.WebApp.Modulos.ModuloMatricula;

public record VisualizarTurmaEMatriculaViewModel(
    Guid Id,
    string Titulo,
    int CapacidadeMaxima,
    string DataInicio,
    string DataTermino,
    string NomeTutor,
    string NomeCurso,
    List<ListarMatriculaViewModel>? Matriculas
);
public record ListarMatriculaViewModel(
    string Id,
    string NomeAluno,
    bool EstaAtiva
);
public record CadastrarMatriculaViewModel(
    string Id,
    string IdAluno
);
public record ExcluirMatriculaViewModel(
    string Id,
    string IdMatricula,
    string NomeAluno,
    string DataMatricua
);