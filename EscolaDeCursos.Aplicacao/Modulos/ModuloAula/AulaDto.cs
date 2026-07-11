namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAula;

public record CadastrarAulaDto(
    string Id,
    string Nome,
    int Duracao
);
public record ExcluirAulaDto(
   string Id,
    string Nome,
    int Duracao,
    string IdCurso
);
public record DetalhesAulaDto(
    string Id,
    string Nome,
    int Duracao,
    string IdCurso
);