using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.Core.DbContext;

namespace TourManagement.Core.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        public readonly DuLichTourContext Context;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository()
        {
            Context = new DuLichTourContext();
            _dbSet = Context.Set<TEntity>();
        }
        public int Add(TEntity entity)
        {
            _dbSet.Add(entity);
            return Context.SaveChanges();
        }

        public bool Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            return Context.SaveChanges() > 0;
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int Id)
        {
            return _dbSet.Find(Id);
        }

        public bool Update(TEntity entity)
        {
            _dbSet.AddOrUpdate(entity);
            return Context.SaveChanges() > 0;
        }
    }
}
