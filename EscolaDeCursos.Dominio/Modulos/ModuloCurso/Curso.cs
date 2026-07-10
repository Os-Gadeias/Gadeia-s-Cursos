using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;

namespace EscolaDeCursos.Dominio.Modulos.ModuloCurso;

public class Curso : EntidadeBase<Curso>
{
    public string Nome { get; set; } = string.Empty;
    public int CargaHoraria { get; set; }
    public NivelDeDificildade Dificuldade { get; set; }
    public Categoria Categoria { get; set; }
    public Curso()
    {
    }
    public Curso(string nome, int cargaHoraria, NivelDeDificildade dificuldade, Categoria categoria)
    {
        Nome = nome;
        CargaHoraria = cargaHoraria;
        Dificuldade = dificuldade;
        Categoria = categoria;
    }

    public override void Atualizar(Curso entidadeAtualizada)
    {
        Nome = entidadeAtualizada.Nome;
        CargaHoraria = entidadeAtualizada.CargaHoraria;
        Dificuldade = entidadeAtualizada.Dificuldade;
        Categoria = entidadeAtualizada.Categoria;
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
