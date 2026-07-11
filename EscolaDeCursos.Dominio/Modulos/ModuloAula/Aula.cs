using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAula;

public class Aula : EntidadeBase<Aula>
{
    public string Nome { get; set; } = string.Empty;
    public int Duracao { get; set; }
    public Guid CursoId { get; set; }

    public Aula(string nome, Guid cursoId, int duracao)
    {
        Nome = nome;
        CursoId = cursoId;
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
            erros.Add("O campo \"Título\" deve conter entre 2 à 100 caracteres!");

        return erros;
    }
}
