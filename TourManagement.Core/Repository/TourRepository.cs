using System.Collections.Generic;
using System.Linq;
using TourManagement.Core.DbContext;

namespace TourManagement.Core.Repository
{
    public class TourRepository : GenericRepository<Tour>, ITourRepository
    {
        public IEnumerable<Tour> GetByCategory(int id)
        {
            return Context.Tours.Where(x => x.Group.Category.CategoryID == id).ToList();
        }

        public IEnumerable<Tour> GetByGroup(string group)
        {
            return Context.Tours.Where(x => x.Group.Name == group).ToList();
        }
    }
}
