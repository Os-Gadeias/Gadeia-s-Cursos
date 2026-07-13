using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;

namespace EscolaDeCursos.Dominio.Modulos.ModuloTurma;

public class Turma : EntidadeBase<Turma>
{
    public string Titulo { get; set; } = string.Empty;
    public int CapacidadeMaxima { get; set; }
    public DateTime DataInicio { get; set; } 
    public DateTime DataTermino { get; set; }
    public Tutor Tutor { get; set; }
    public Curso Curso { get; set; }
    public List<Aluno> Alunos = [];

    public Turma()
    {
    }

    public Turma(string titulo, int capacidadeMaxima, DateTime dataInicio, DateTime dataTermino, Tutor tutor, Curso curso)
    {
        Titulo = titulo;
        CapacidadeMaxima = capacidadeMaxima;
        DataInicio = dataInicio;
        DataTermino = dataTermino;
        Tutor = tutor;
        Curso = curso;
    }

    public override void Atualizar(Turma entidadeAtualizada)
    {
        Titulo = entidadeAtualizada.Titulo;
        CapacidadeMaxima = entidadeAtualizada.CapacidadeMaxima;
        DataTermino = entidadeAtualizada.DataTermino;
        Tutor = entidadeAtualizada.Tutor;
        Curso = entidadeAtualizada.Curso;
    }

    public override List<string> Validar()
    {
        List<string> erros = [];

        if (Titulo.Length < 2 || Titulo.Length > 100)
            erros.Add("O \"Titulo\" deve conter entre 2 à 100 caracteres");

        if (Alunos.Count > CapacidadeMaxima)
            erros.Add($"Limite da turma: {CapacidadeMaxima} atingido!");

        if (DataTermino < DataInicio)
            erros.Add("A data de término deve ser maior que a data atual!");

        return erros;
    }
}
