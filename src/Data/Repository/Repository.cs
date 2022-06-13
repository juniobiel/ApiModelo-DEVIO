using Business.Interfaces;
using Business.Models;
using Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Data.Repository
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {
        protected readonly DataDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        protected Repository(DataDbContext db)
        {
            Db = db;
            DbSet = db.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Buscar( Expression<Func<TEntity, bool>> predicate )
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> ObterPorId( Guid id )
        {
            return await DbSet.FindAsync(id);
        }

        public virtual async Task<List<TEntity>> ObterTodos()
        {
            return await DbSet.AsNoTracking().ToListAsync();
        }

        public virtual async Task Adicionar( TEntity entity )
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Atualizar( TEntity entity )
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Remover( Guid id )
        {
            DbSet.Remove(new TEntity { Id = id });
            await SaveChanges();
        }

        public async Task<int> SaveChanges()
        {
            return await Db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Db?.Dispose();
        }
    }
}
