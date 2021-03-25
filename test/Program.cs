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
        private static readonly IDestinationRepository destinationRepository = new DestinationRepository();


        static void Main(string[] args)
        {
            var distinations = destinationRepository.GetAll();

            foreach (var distination in distinations)
            {
                Console.WriteLine(distination.Name);
            }
            Console.ReadKey();
        }
    }
}
