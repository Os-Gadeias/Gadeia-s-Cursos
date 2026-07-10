using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Aplicacao.Modulos.ModuloCategoria;
using EscolaDeCursos.Dominio.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloTutor;
using FluentResults;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloTutor;

public class ServicoTutor : ServicoBase<Tutor>
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

    public Result Cadastrar(CadastrarTutorDto dto)
    {
        Tutor novoTutor = new(dto.Nome, dto.Telefone, dto.Cpf);

        Result resultadoValidacao = ValidarEntidade(novoTutor);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteTutorComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já existe um tutor com esse Nome");

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
            return Falha(nameof(dto.Nome), "Já existe um tutor com esse Nome");

        repositorioTutor.Editar(dto.Id, tutorEditado);

        return Result.Ok();
    }

    public void Excluir(ExcluirTutorDto dto)
    {
        Tutor? t = repositorioTutor.SelecionarPorId(dto.Id);

        if (t == null)
            throw new Exception("Tutor não encontrado!");

        repositorioTutor.Excluir(dto.Id);
    }

    public ListarTutorDto SelecionarPorId(Guid id)
    {
        Tutor? t = repositorioTutor.SelecionarPorId(id);

        if (t == null)
            throw new Exception("Tutor não encontrado!");

        return new ListarTutorDto(t.Id, t.Nome, t.Telefone, t.Cpf);
    }

    public bool ExisteTutorComMesmoNome(string Nome, Guid? idIgnorado = null)
    {
        return repositorioTutor.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Nome, Nome, StringComparison.OrdinalIgnoreCase));
    }
}
