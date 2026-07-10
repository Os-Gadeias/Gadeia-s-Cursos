using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

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
    [ApenasUmEmoji(ErrorMessage = "Você deve escolher apenas 1 emoji.")]
    string Icon
);
public record ExcluirCategoriaViewModel(
    string Id,
    string Titulo,
    string Cor,
    string Icon
);
public record EditarCategoriaViewModel(
    string Id,
    [Required(ErrorMessage = "O campo \"Titulo\" é Obrigatório!")]
    string Titulo,
    [Required(ErrorMessage = "O campo \"Cor\" é Obrigatório!")]
    string Cor,
    [Required(ErrorMessage = "O campo \"Emoji\" é Obrigatório!")]
    [ApenasUmEmoji(ErrorMessage = "Você deve escolher apenas 1 emoji.")]
    string Icon
);
