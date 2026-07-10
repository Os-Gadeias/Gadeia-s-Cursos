using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTutor;

public class ServicoTutor
{
    private readonly IRepositorioTutor repositorioTutor;

    public ServicoTutor(IRepositorioTutor repositorioTutor)
    {
        this.repositorioTutor = repositorioTutor;
    }

    public List<ListarTutorDto> SelecionarTodos()
    {
        return repositorioTutor.SelecionarTodos().Select(t => new ListarTutorDto(
            t.Id,
            t.Nome,
            t.Telefone,
            t.Cpf
        )).ToList();
    }
}
