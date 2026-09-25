using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
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
    public List<Matricula> Matriculas = [];

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
            erros.Add("Titulo|The \"Title\" must be between 2 and 100 characters.");

        if (Matriculas.Count > CapacidadeMaxima)
            erros.Add($"CapacidadeMaxima|Class capacity limit reached: {CapacidadeMaxima}.");

        if (DataTermino < DataInicio)
            erros.Add("DataTermino|The end date must be later than the start date!");

        if (CapacidadeMaxima <= 0)
            erros.Add("CapacidadeMaxima|The \"Maximum Capacity\" field must be greater than zero!");
        return erros;
    }
}
