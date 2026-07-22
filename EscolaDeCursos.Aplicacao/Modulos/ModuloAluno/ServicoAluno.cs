using System.Data.Common;
using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAluno;
using EscolaDeCursos.Dominio.Modulos.ModuloMatricula;
using FluentResults;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAluno;

public class ServicoAluno : ServicoBase<Aluno>
{
    private readonly IRepositorioAluno repositorioAluno;
    private readonly IRepositorioMatricula repositorioMatricula;

    public ServicoAluno(IRepositorioAluno repositorioAluno, IRepositorioMatricula repositorioMatricula)
    {
        this.repositorioAluno = repositorioAluno;
        this.repositorioMatricula = repositorioMatricula;
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

        if (ExisteAlunoComMesmoTelefone(dto.Telefone))
            return Falha(nameof(dto.Telefone), "Já axiste um Aluno com esse Telefone!");

        if (ExisteAlunoComMesmoCpf(dto.Cpf))
            return Falha(nameof(dto.Cpf), "Já axiste um Aluno com esse CPF!");

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

        if (ExisteAlunoComMesmoTelefone(dto.Telefone, dto.Id))
            return Falha(nameof(dto.Telefone), "Já axiste um Aluno com esse Telefone!");

        if (ExisteAlunoComMesmoCpf(dto.Cpf, dto.Id))
            return Falha(nameof(dto.Cpf), "Já axiste um Aluno com esse CPF!");

        repositorioAluno.Editar(dto.Id, AlunoEditado);

        return Result.Ok();
    }

    public Result Excluir(ExcluirAlunoDto dto)
    {
        Aluno? alunoSelecionado = repositorioAluno.SelecionarPorId(dto.Id);

        if (alunoSelecionado == null)
            return Result.Fail("Tutor não encontrado!");

        if (AlunoEstaMatriculadoEmCurso(alunoSelecionado.Id))
            return Result.Fail("Não é possível excluir aluno matriculado em um curso!");

        repositorioAluno.Excluir(dto.Id);

        return Result.Ok();
    }

    public ListarAlunoDto SelecionarPorId(Guid id)
    {
        Aluno? aluno = repositorioAluno.SelecionarPorId(id);

        if (aluno == null)
            throw new Exception("Aluno não encontrado!");

        return new ListarAlunoDto(aluno.Id, aluno.Nome, aluno.Telefone, aluno.Cpf);
    }

    private bool ExisteAlunoComMesmoNome(string Nome, Guid? idIgnorado = null)
    {
        return repositorioAluno.SelecionarTodos().Any(e => e.Id != idIgnorado &&
            string.Equals(e.Nome, Nome, StringComparison.OrdinalIgnoreCase));
    }
    private bool AlunoEstaMatriculadoEmCurso(Guid id)
    {
        return repositorioMatricula.SelecionarTodos().Any(m => m.Aluno.Id == id);
    }
    private bool ExisteAlunoComMesmoTelefone(string telefone, Guid? idIgnorado = null)
    {
        return repositorioAluno.SelecionarTodos().Any(a => a.Telefone == telefone && a.Id != idIgnorado);
    }
    private bool ExisteAlunoComMesmoCpf(string Cpf, Guid? idIgnorado = null)
    {
        return repositorioAluno.SelecionarTodos().Any(a => a.Cpf == Cpf && a.Id != idIgnorado);
    }
}
