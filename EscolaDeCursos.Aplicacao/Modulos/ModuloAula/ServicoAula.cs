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
}
