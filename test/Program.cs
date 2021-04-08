using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourManagement.Core.Repository;

namespace test
{
    class Program
    {
        private static readonly EmployeeRepository employeeRepository= new EmployeeRepository();

        [Obsolete]
        static void Main(string[] args)
        {
            DateTime ts = DateTime.Parse("2021-05-13");
            int time = 4;
            var emps = employeeRepository.GetEmployeeFree(ts, time);

            Console.WriteLine(emps);
            foreach (var item in emps)
            {
                Console.WriteLine(item.Name);
            }

            Console.ReadKey();
        }
    }
}
