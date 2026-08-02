using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloAutenticacao;

public record RegistrarViewModel
{
    [Required(ErrorMessage = "O Campo \"Nome\" deve ser Preenchido!")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O Campo Nome \"Nome\" deve conter entre 2 à 100 caracteres!")]
    public string Nome { get; init; } = string.Empty;
    [Required(ErrorMessage = "O Campo \"Email\" deve ser Preenchido!")]
    [StringLength(256, ErrorMessage = "O Campo Email \"Email\" deve conter 256 caracteres maximos!")]
    [EmailAddress(ErrorMessage = "O Campo\"Email\" deve conter um email valido!")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "O Campo \"Senha\" deve ser Preenchido!")]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "O campo \"Senha\" deve conter no mínimo 8 caracteres!")]
    public string Senha { get; init; } = string.Empty;
    [Required(ErrorMessage = "O Campo \"Confirmar senha\" deve ser Preenchido!")]
    [DataType(DataType.Password)]
    [Compare(nameof(Senha), ErrorMessage = "As senhas não conferem!")]
    public string ConfirmarSenha { get; init; } = string.Empty;
}
public record EntrarViewModel
{
    [Required(ErrorMessage = "O campo \"E-mail\" deve ser preenchido.")]
    [EmailAddress(ErrorMessage = "O campo \"E-mail\" deve conter um endereço de e-mail válido.")]
    public string Email { get; init; } = string.Empty;

    [Required(ErrorMessage = "O campo \"Senha\" deve ser preenchido.")]
    [DataType(DataType.Password)]
    public string Senha { get; init; } = string.Empty;

    public bool LembrarMe { get; init; }

    public string? ReturnUrl { get; init; }
}
