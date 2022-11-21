using Avito.DataAccess.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Avito.DataAccess.Postgres.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext DbContext;

        protected GenericRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }

        public List<TEntity> GetAll(CancellationToken cancellationToken = default)
        {
            return DbContext.Set<TEntity>().AsQueryable().ToList();
        }

        public TEntity Add(TEntity entity)
        {
            return DbContext.Set<TEntity>()
                .Add(entity)
                .Entity;
        }

        public TEntity Update(TEntity entity)
        {
            return DbContext.Set<TEntity>().Update(entity).Entity;
        }

        public void Update(List<TEntity> entities)
        {
            DbContext.Set<TEntity>().UpdateRange(entities);
        }

        public void Save()
        {
            DbContext.SaveChanges();
        }
    }
}