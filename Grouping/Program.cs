using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
namespace Grouping
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
                var groups = db.Phones.GroupBy(p => p.Company.Name);
                foreach (var item in groups)
                {
                    Console.WriteLine(item.Key);
                    foreach (var innerItem in item)
                    {
                        Console.WriteLine($"{innerItem.Name} - {innerItem.Price}");
                    }
                }
                Console.WriteLine(new string('-', 40));

                var group1 = db.Phones.GroupBy(p => p.Company.Name);
                foreach (var item in group1)
                {
                    Console.WriteLine($"{item.Key} - {item.Count()}");
                    foreach (var innerItem in item)
                    {
                        Console.WriteLine($"{innerItem.Id}.{innerItem.Name} - {innerItem.Price}");
                    }
                }


                Console.WriteLine(new string('-', 40));
            }
        }
    }
}
