using EscolaDeCursos.Dominio.Modulos.ModuloCurso;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloCurso;

public class RepositorioCursoOrm(EscolaDeCursosDbContext dbContext) :
RepositorioBaseEmOrm<Curso>(dbContext), IRepositorioCurso;