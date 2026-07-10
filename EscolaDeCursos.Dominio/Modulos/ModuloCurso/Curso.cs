using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public NivelDeDificildade Dificildade { get; set; }
    public Categoria Categoria { get; set; }
    //public List<Aula> Aulas = new();
    public Curso(string nome, int cargaHoraria, NivelDeDificildade dificildade, Categoria categoria)
    {
        Nome = nome;
        CargaHoraria = cargaHoraria;
        Dificildade = dificildade;
        Categoria = categoria;
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
        Dificildade = entidadeAtualizada.Dificildade;
        Categoria = entidadeAtualizada.Categoria;
        // Aulas = entidadeAtualizada.Aulas;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Nome.Length < 2 || Nome.Length > 100)
            erros.Add("O campo \"Título\" deve conter entre 2 à 100 caracteres!");

        if (CargaHoraria <= 0)
            erros.Add("O campo \'Carga Horária\" deve conter um valor MAIOR que zero!");

        return erros;
    }
}
