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
    [Required(ErrorMessage = "The Title field is required.")]
    string Titulo,
    [Required(ErrorMessage = "The Color field is required.")]
    string Cor,
    [Required(ErrorMessage = "The Emoji field is required.")]
    [ApenasUmEmoji(ErrorMessage = "Please select exactly one emoji.")]
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
    [Required(ErrorMessage = "The Title field is required.")]
    string Titulo,
    [Required(ErrorMessage = "The Color field is required.")]
    string Cor,
    [Required(ErrorMessage = "The Emoji field is required.")]
    [ApenasUmEmoji(ErrorMessage = "Please select exactly one emoji.")]
    string Icon
);
