namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;

public record DetalhesCategoriaDto(
    string Id,
    string Titulo,
    string Cor,
    string Icon
);
public record CadastrarCategoriaDto(
    string Titulo,
    string Cor,
    string Icon
);
public record ExcluirCategoriaDto(
    string Id,
    string Titulo,
    string Cor,
    string Icon
);