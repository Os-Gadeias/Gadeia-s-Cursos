using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAula;

public class Aula : EntidadeBase<Aula>
{
    public string Nome { get; set; } = string.Empty;
    public int Duracao { get; set; }
    public Curso Curso { get; set; }
    public Aula()
    {
    }
    public Aula(string nome, int duracao, Curso cursoId)
    {
        Nome = nome;
        Curso = cursoId;
        Duracao = duracao;
    }
    public override void Atualizar(Aula entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Duracao = entidadeAtualizada.Duracao;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("Titulo|The \"Title\" field must be between 2 and 100 characters!");

        return erros;
    }
}
