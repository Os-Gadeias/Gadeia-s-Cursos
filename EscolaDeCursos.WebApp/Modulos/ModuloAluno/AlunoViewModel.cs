using System.ComponentModel.DataAnnotations;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCategoria.ModuloAluno;

public record ListarAlunoViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

public record CadastrarAlunoViewModel(

    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The Name field must be between 2 and 100 characters.")]
    string Nome,

    [Required(ErrorMessage = "The Phone field is required.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "The phone number must use the format (DDD ) 90000-0000.")]
    string Telefone,

    [Required(ErrorMessage = "The CPF field is required.")]
    [StringLength(11, ErrorMessage = "The CPF field cannot exceed 11 characters.")]
    string Cpf
);

public record EditarAlunoViewModel(
    Guid Id,

    [Required(ErrorMessage = "The Name field is required.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "The Name field must be between 2 and 100 characters.")]
    string Nome,

    [Required(ErrorMessage = "The Phone field is required.")]
    [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "The phone number must use the format (area code) 90000-0000.")]
    string Telefone,

    [Required(ErrorMessage = "The CPF field is required.")]
    [StringLength(11, ErrorMessage = "The CPF field cannot exceed 11 characters.")]
    string Cpf
);

public record ExcluirAlunoViewModel(
    Guid Id,
    string Nome,
    string Telefone,
    string Cpf
);

