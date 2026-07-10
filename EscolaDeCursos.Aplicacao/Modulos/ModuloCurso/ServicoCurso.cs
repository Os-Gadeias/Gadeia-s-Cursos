using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public class ServicoCurso : ServicoBase<Curso>
{
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoCurso(IRepositorioCurso repositorioCurso)
    {
        this.repositorioCurso = repositorioCurso;
    }
    public List<DetalhesCursoDto> SelecionarTodos()
    {
        return repositorioCurso.SelecionarTodos().Select(c => new DetalhesCursoDto(
            c.Id.ToString(),
            c.Nome,
            c.CargaHoraria,
            c.Dificuldade,
            c.Categoria.Titulo
        )).ToList();
    }
}
