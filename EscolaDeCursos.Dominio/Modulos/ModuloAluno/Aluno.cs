using System.Text.RegularExpressions;
using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAluno;

public class Aluno : EntidadeBase<Aluno>
{
    public string Nome { get; set; } = string.Empty;
    public string Telefone { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;

    public Aluno() { }

    public Aluno(string nome, string telefone, string cpf)
    {
        Nome = nome;
        Telefone = telefone;
        Cpf = cpf;
    }

    public override void Atualizar(Aluno entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Telefone = entidadeAtualizada.Telefone;
        Cpf = entidadeAtualizada.Cpf;
    }

    public override List<string> Validar()
    {
        List<string> erros = new List<string>();

        if (string.IsNullOrWhiteSpace(Nome))
            erros.Add("Nome|O campo \"Nome\" deve ser preenchido!");

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("Nome|O campo \"Nome\" deve conter entre 2 e 100 caracteres!");

        if (string.IsNullOrWhiteSpace(Telefone))
            erros.Add("Telefone|O campo \"Telefone\" deve ser preenchido!");

        if (!Regex.IsMatch(Telefone, @"^\(\d{2}\) \d{4,5}-\d{4}$"))
            erros.Add("Telefone|O campo \"Telefone\" deve estar no formato (DDD) 90000-0000.");

        if (string.IsNullOrWhiteSpace(Cpf))
            erros.Add("Cpf|O campo \"CPF\" deve ser preenchido!");

        if (Cpf.Length != 11)
            erros.Add("Cpf|O campo \"CPF\" deve conter 11 caracteres!");

        return erros;
    }
}