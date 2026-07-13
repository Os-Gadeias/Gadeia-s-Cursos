using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;

namespace EscolaDeCursos.Dominio.Modulos.ModuloMatricula;

public class Matricula : EntidadeBase<Matricula>
{
    public DateTime DataMatricula = DateTime.Now;
    public bool EstaAtiva = true;
    public Aluno Aluno { get; set; }
    public Turma Turma { get; set; }

    public Matricula()
    {

    }
    public Matricula(Aluno aluno, Turma turma)
    {
        Aluno = aluno;
        Turma = turma;
    }

    public override void Atualizar(Matricula entidadeAtualizada)
    {
        throw new NotImplementedException();
    }

    public override List<string> Validar()
    {
        throw new NotImplementedException();
    }
}
