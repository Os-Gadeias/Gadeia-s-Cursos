using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAutenticacao;

public record RegistrarViewModel
{
    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The Name field must be between 2 and 100 characters.")]
    public string Nome { get; init; } = string.Empty;
    [Required(ErrorMessage = "The Email field is required.")]
    [StringLength(256, ErrorMessage = "The Email field must not exceed 256 characters.")]
    [EmailAddress(ErrorMessage = "The Email field must contain a valid email address.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "The Password field is required.")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "The Password field must be at least 8 characters long.")]
    public string Senha { get; init; } = string.Empty;
    [Required(ErrorMessage = "The Confirm Password field is required.")]
    [DataType(DataType.Password)]
    [Compare(nameof(Senha), ErrorMessage = "The passwords do not match.")]
    public string ConfirmarSenha { get; init; } = string.Empty;
}
public record EntrarViewModel
{
    [Required(ErrorMessage = "The Email field is required.")]
    [EmailAddress(ErrorMessage = "The Email field must contain a valid email address.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "The Password field is required.")]
    [DataType(DataType.Password)]
    public string Senha { get; init; } = string.Empty;

    public bool LembrarMe { get; init; }

    public string? ReturnUrl { get; init; }
}
