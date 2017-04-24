using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataContext
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
               var companies = db.Companies.ToList();

                foreach (var item in companies)
                {

                    Console.WriteLine($"{item.Id}.{item.Name}");
                }
            }

        }
    }
}
