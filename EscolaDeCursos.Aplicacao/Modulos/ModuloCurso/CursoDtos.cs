using System.ComponentModel.DataAnnotations;
using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.Aplicacao.Modulos.ModuloCurso;

public record DetalhesCursoDto(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome
);
public record CadastrarCursoDto(
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaId
);
public record ExcluirCursoDto(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome
);
public record EditarCursoDto(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaId
);
public record DetalhesCursoECategoriaDto(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaId
);
public record VisualizarTurmaEAulasDto(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome,
    List<ListarAulasDto>? Aulas
);
public record ListarAulasDto(
    string Id,
    string Nome,
    int Duracao
);