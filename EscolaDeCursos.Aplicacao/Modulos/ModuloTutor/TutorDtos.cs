public record ListarTutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record CadastrarTutorDto(
    string Nome,
    string Telefone,
    string Cpf
);

public record EditarTutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record ExcluirTutorDto(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);
