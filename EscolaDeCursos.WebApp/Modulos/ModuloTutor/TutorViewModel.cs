using System.ComponentModel.DataAnnotations;
using System.Configuration;

public record ListarTutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record CadastrarTutorViewMosel(

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido!")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido!")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O campo \"Telefone\" deve estar no formato (DDD) 90000-0000.")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"CPF\" deve ser preenchido!")]
    [StringLength(11, ErrorMessage = "O campo \"CPF\" deve conter 11 caracteres!")]
    string Cpf
);

public record EditarTutorViewMosel(
    Guid Id,

    [Required(ErrorMessage = "O campo \"Nome\" deve ser preenchido!")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "O campo \"Nome\" deve conter entre 2 e 100 caracteres")]
    string Nome,

    [Required(ErrorMessage = "O campo \"Telefone\" deve ser preenchido!")]
    string Telefone,

    [Required(ErrorMessage = "O campo \"CPF\" deve ser preenchido!")]
    [StringLength(11, ErrorMessage = "O campo \"CPF\" deve conter 11 caracteres!")]
    string Cpf
);

public record ExcluirTutorViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);
