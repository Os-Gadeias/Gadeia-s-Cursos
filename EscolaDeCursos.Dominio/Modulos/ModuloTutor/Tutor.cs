using System.Text.RegularExpressions;
using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloTutor;

public class Tutor : EntidadeBase<Tutor>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Tutor() { }

    public Tutor(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    public override void Atualizar(Tutor entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        Cpf = entidadeAtualizada.Cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("Nome|The \"Name\" field is required!");

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("Nome|The \"Name\" field must be between 2 and 100 characters!");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("Telefone|The \"Phone\" field is required!");

        if (!Regex.IsMatch(Telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
            erros.Add("Telefone|The phone number must use the format (area code) 90000-0000.");

        if (string.IsNullOrWhiteSpace(Cpf))
            erros.Add("Cpf|The \"CPF\" field is required!");

        if (Cpf.Length != 11)
            erros.Add("Cpf|The \"CPF\" field must contain 11 characters!");

        return erros;
    }
}
