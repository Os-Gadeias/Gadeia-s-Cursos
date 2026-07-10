using EscolaDeCursos.Dominio.Modulos.ModuloCategoria;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos;

public class RepositorioCategoriaEmOrm(EscolaDeCursosDbContext dbContext)
    : RepositorioBaseEmOrm<Categoria>(dbContext), IRepositorioCategoria;
