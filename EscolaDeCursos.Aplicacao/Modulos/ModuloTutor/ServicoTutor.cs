using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTurma;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using FluentResults;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTutor;

public class ServicoTutor : ServicoBase<Tutor>
{
    private readonly IRepositorioTutor repositorioTutor;
    private readonly IRepositorioTurma repositorioTurma;

    public ServicoTutor(IRepositorioTutor repositorioTutor, IRepositorioTurma repositorioTurma)
    {
        this.repositorioTutor = repositorioTutor;
        this.repositorioTurma = repositorioTurma;
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

    public Result Cadastrar(CadastrarTutorDto dto)
    {
        Tutor novoTutor = new(dto.Nome, dto.Telefone, dto.Cpf);

        Result resultadoValidacao = ValidarEntidade(novoTutor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteTutorComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "A tutor with this name already exists.");

        if (ExisteTutorComMesmoTelefone(dto.Telefone))
            return Falha(nameof(dto.Telefone), "A tutor with this phone number already exists.");

        if (ExisteTutorComMesmoCpf(dto.Cpf))
            return Falha(nameof(dto.Cpf), "A tutor with this CPF already exists.");

        repositorioTutor.Cadastrar(novoTutor);

        return Result.Ok();
    }

    public Result Editar(EditarTutorDto dto)
    {
        Tutor tutorEditado = new(dto.Nome, dto.Telefone, dto.Cpf);

        Result resultadoValidacao = ValidarEntidade(tutorEditado);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteTutorComMesmoNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "A tutor with this name already exists.");

        if (ExisteTutorComMesmoTelefone(dto.Telefone, dto.Id))
            return Falha(nameof(dto.Telefone), "A tutor with this phone number already exists.");

        if (ExisteTutorComMesmoCpf(dto.Cpf, dto.Id))
            return Falha(nameof(dto.Cpf), "A tutor with this CPF already exists.");

        repositorioTutor.Editar(dto.Id, tutorEditado);

        return Result.Ok();
    }

    public Result Excluir(ExcluirTutorDto dto)
    {
        Tutor? t = repositorioTutor.SelecionarPorId(dto.Id);

        if (t == null)
            return Result.Fail("Tutor not found.");

        if (ExisteTutorAtreladoATurma(t.Id))
            return Result.Fail("Cannot delete a tutor assigned to a class.");

        repositorioTutor.Excluir(dto.Id);

        return Result.Ok();
    }

    public ListarTutorDto SelecionarPorId(Guid id)
    {
        Tutor? t = repositorioTutor.SelecionarPorId(id);

        if (t == null)
            throw new Exception("Tutor not found.");

        return new ListarTutorDto(t.Id, t.Nome, t.Telefone, t.Cpf);
    }

    private bool ExisteTutorComMesmoNome(string Nome, Guid? idIgnorado = null)
    {
        return repositorioTutor.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Nome, Nome, StringComparison.OrdinalIgnoreCase));
    }

    private bool ExisteTutorAtreladoATurma(Guid id)
    {
        return repositorioTurma.SelecionarTodos().Any(t => t.Tutor.Id == id);
    }

    private bool ExisteTutorComMesmoTelefone(string telefone, Guid? idIgnorado = null)
    {
        return repositorioTutor.SelecionarTodos().Any(t => t.Telefone == telefone && t.Id != idIgnorado);
    }
    private bool ExisteTutorComMesmoCpf(string Cpf, Guid? idIgnorado = null)
    {
        return repositorioTutor.SelecionarTodos().Any(t => t.Cpf == Cpf && t.Id != idIgnorado);
    }
}
