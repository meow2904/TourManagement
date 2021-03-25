using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourManagement.Core.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int Id);

        int Add(TEntity entity);
        bool Update(TEntity entity);
        bool Delete(TEntity entity);
        
    }
}
