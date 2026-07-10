using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria;

public record ListarCategoriaViewModel(
    string Id,
    string Titulo,
    string Cor,
    string Icon
);
public record CadastrarCategoriaViewModel(
    [Required(ErrorMessage = "O campo \"Titulo\" é Obrigatório!")]
    string Titulo,
    [Required(ErrorMessage = "O campo \"Cor\" é Obrigatório!")]
    string Cor,
    [Required(ErrorMessage = "O campo \"Emoji\" é Obrigatório!")]
    string Icon
);
public record ExcluirCategoriaViewModel(
    string Id,
    string Titulo,
    string Cor,
    string Icon
);
