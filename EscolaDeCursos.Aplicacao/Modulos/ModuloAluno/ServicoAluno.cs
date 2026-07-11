using System.Data.Common;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using FluentResults;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public class ServicoAluno : ServicoBase<Aluno>
{
    private readonly IRepositorioAluno repositorioAluno;

    public ServicoAluno(IRepositorioAluno repositorioAluno)
    {
        this.repositorioAluno = repositorioAluno;
    }

    public List<ListarAlunoDto> SelecionarTodos()
    {                                             //Select = para cada " "
        return repositorioAluno.SelecionarTodos().Select(t => new ListarAlunoDto(
            t.Id,
            t.Nome,
            t.Telefone,
            t.Cpf
        )).ToList();
    }

    public Result Cadastrar(CadastrarAlunoDto dto)
    {
        Aluno novoAluno = new(dto.Nome, dto.Telefone, dto.Cpf);

        Result resultadoValidacao = ValidarEntidade(novoAluno);

        if (resultadoValidacao.IsFailed)
            return resultadoValidacao;

        if (ExisteAlunoComMesmoNome(dto.Nome))
            return Falha(nameof(dto.Nome), "Já axiste um Aluno com esse nome");

        repositorioAluno.Cadastrar(novoAluno);

        return Result.Ok();
    }

    public Result Editar(EditarAlunoDto dto)
    {
        Aluno AlunoEditado = new(dto.Nome, dto.Telefone, dto.Cpf);

        Result resultValidacao = ValidarEntidade(AlunoEditado);

        if (resultValidacao.IsFailed)
            return resultValidacao;

        if (ExisteAlunoComMesmoNome(dto.Nome, dto.Id))
            return Falha(nameof(dto.Nome), "Já existe um Aluno com esse nome");

        repositorioAluno.Editar(dto.Id, AlunoEditado);

        return Result.Ok();
    }

    public void Excluir(ExcluirAlunoDto dto)
    {
        Aluno? alunoSelecionado = repositorioAluno.SelecionarPorId(dto.Id);

        if (alunoSelecionado == null)
            throw new Exception("Tutor não encontrado!");

        repositorioAluno.Excluir(dto.Id);
    }

    public ListarAlunoDto SelecionarPorId(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if (aluno == null)
            throw new Exception("Aluno não encontrado!");

        return new ListarAlunoDto(aluno.Id, aluno.Nome, aluno.Telefone, aluno.Cpf);
    }

    public bool ExisteAlunoComMesmoNome(string Nome, Guid? idIgnorado = null)
    {
        return repositorioAluno.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Nome, Nome, StringComparison.OrdinalIgnoreCase));
    }
}
