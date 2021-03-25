using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.Core.DbContext;

namespace TourManagement.Core.Repository
{
    public interface ITourRepository : IGenericRepository<Tour>
    {
        IEnumerable<Tour> GetByCategory(int id);
        IEnumerable<Tour> GetByGroup(string group);
    }
}
