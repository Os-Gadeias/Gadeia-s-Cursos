namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public record ListarCategoriaViewModel(
    string Id,
    string Titulo,
    string Cor,
    string Icon
);
public record CadastrarCategoriaViewModel(
    string Titulo,
    string Cor,
    string Icon
);
