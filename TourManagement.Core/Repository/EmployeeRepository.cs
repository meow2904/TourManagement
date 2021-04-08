using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.Core.DbContext;

namespace TourManagement.Core.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        [Obsolete]
        public IEnumerable<Employee> GetEmployeeFree(DateTime datePick, int time)
        {
            //get employee working on datepick
            //datepick + time = timeEnd
            var emps = Context.Tours.Where(t => (t.TimeStart >= datePick && t.TimeStart <= EntityFunctions.AddDays(datePick,time)) ||
                                                EntityFunctions.AddDays(t.TimeStart,t.Time) >= datePick &&
                                                EntityFunctions.AddDays(t.TimeStart, t.Time) <= EntityFunctions.AddDays(datePick,time))
                                    .Select(e => e.EmployeeID);

            var employees = Context.Employees.Where(e => !emps.Contains(e.EmployeeID)).ToList();
            return employees;
        }
    }
}
