using EscolaDeCursos.Dominio.Modulos.ModuloAula;
using EscolaDeCursos.Infra.Compartilhado.Orm;

namespace EscolaDeCursos.Infra.Modulos.ModuloAula;

public class RepositorioAulaEmOrm(EscolaDeCursosDbContext dbContext) 
    : RepositorioBaseEmOrm<Aula>(dbContext), IRepositorioAula;