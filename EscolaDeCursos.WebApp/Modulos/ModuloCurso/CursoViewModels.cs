using EscolaDeCursos.Dominio.Modulos.ModuloCurso;

namespace EscolaDeCursos.WebApp.Modulos.ModuloCurso;

public record ListarCursoViewModel(
    string Id,
    string Nome,
    int CargaHoraria,
    NivelDeDificildade Dificuldade,
    string CategoriaNome
);
