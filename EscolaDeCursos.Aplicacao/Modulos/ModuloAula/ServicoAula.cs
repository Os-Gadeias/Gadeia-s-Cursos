using EscolaDeCursos.Aplicacao.Compartilhado;
using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using FluentResults;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloAula;

public class ServicoAula : ServicoBase<Aula>
{
    private readonly IRepositorioAula repositorioAula;
    private readonly IRepositorioCurso repositorioCurso;

    public ServicoAula(IRepositorioAula repositorioAula, IRepositorioCurso repositorioCurso)
    {
        this.repositorioAula = repositorioAula;
        this.repositorioCurso = repositorioCurso;
    }

    public Result AdicionarAula(CadastrarAulaDto dto)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(new Guid(dto.Id));

        if (curso == null)
            return Result.Fail("Curso não encontrado!");

        Aula aula = new(dto.Nome, dto.Duracao, curso);

        repositorioAula.Cadastrar(aula);

        return Result.Ok();
    }
    public Result<DetalhesAulaDto> SelecionarPorId(string id)
    {
        Aula? aula = repositorioAula.SelecionarPorId(new Guid(id));

        if (aula == null)
            return Result.Fail("Aula não encontrada!");

        return new DetalhesAulaDto(aula.Id.ToString(), aula.Nome, aula.Duracao, aula.Curso.Id.ToString());
    }
    public Result ExcluirMatricula(ExcluirAulaDto dto)
    {
        Aula? aula = repositorioAula.SelecionarPorId(new Guid(dto.Id));

        if (aula == null)
            return Result.Fail("Aula não encontrada!");

        repositorioAula.Excluir(new Guid(dto.Id));

        return Result.Ok();
    }

    public Result EditarAula(EditarAulaDto dto)
    {
        Curso? curso = repositorioCurso.SelecionarPorId(new Guid(dto.IdCurso));

        if (curso == null)
            return Result.Fail("Curso não encontrado!");

        Aula aula = new(dto.Nome, dto.Duracao, curso);

        repositorioAula.Editar(new Guid(dto.Id), aula);

        return Result.Ok();
    }
}
