namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public record ListarAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record CadastrarAlunoDto(

    string Nome,
    string Telefone,
    string Cpf
);

public record EditarAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record ExcluirAlunoDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);
