using Microsoft.EntityFrameworkCore;
using RdxServer.Context;
using RdxServer.Entities;
using RdxServer.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RdxServer.Repositories
{
    public abstract class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : EntityBase, new()
    {
        protected readonly RdxDBContext Db;
        protected readonly DbSet<TEntity> DbSet;

        public RepositoryBase(RdxDBContext db)
        {
            Db = db ?? throw new ArgumentNullException(nameof(db));
            DbSet = db.Set<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> Find(Expression<Func<TEntity, bool>> predicate)
        {
            return await DbSet.AsNoTracking().Where(predicate).ToListAsync();
        }

        public virtual async Task<TEntity> GetById(int Id)
        {
            return await DbSet.FindAsync(Id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public virtual async Task Add(TEntity entity)
        {
            DbSet.Add(entity);
            await SaveChanges();
        }

        public virtual async Task Update(TEntity entity)
        {
            DbSet.Update(entity);
            await SaveChanges();
        }

        public virtual async Task Delete(int Id)
        {
            DbSet.Remove(new TEntity { Id = Id });
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
