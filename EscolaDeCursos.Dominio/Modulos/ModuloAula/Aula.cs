using EscolaDeCursos.Dominio.Compartilhado;

namespace EscolaDeCursos.Dominio.Modulos.ModuloAula;

public class Aula : EntidadeBase<Aula>
{
    public string Nome { get; set; } = string.Empty;
    public DateTime Inicio { get; set; }
    public DateTime Fim { get; set; }
    public Guid CursoId { get; set; }

    public Aula(string nome, DateTime inicio, DateTime fim, Guid cursoId)
    {
        Nome = nome;
        Inicio = inicio;
        Fim = fim;
        CursoId = cursoId;
    }
    public override void Atualizar(Aula entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        Inicio = entidadeAtualizada.Inicio;
        Fim = entidadeAtualizada.Fim;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Título\" deve conter entre 2 à 100 caracteres!");

        if (Fim < Inicio)
            erros.Add("O Inicío da Aula deve ser antes do Fim!");

        return erros;
    }
}
