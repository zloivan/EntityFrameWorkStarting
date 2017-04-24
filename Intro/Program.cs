using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
namespace Intro
{
    class Program
    {
        static DataModel db;
        public static void Output(IQueryable<Phone> queue)
        {
            foreach (var item in queue)
            {
                Console.WriteLine($"{item.Id}.{item.Name} - {item.Price}");
            }
        }
        static void Main(string[] args)
        {
            using (db = new DataModel())
            {
                ShowDetails(db.Phones.Where(p => p.Price <= 10000).Select(p => p));
                ShowDetails(db.Phones.Where(p => p.Price <= 10000));
                ShowDetails(db.Phones.Where(p => p.Price <= 10000).ToList().Where(p => p.CompanyId > 1));
                Console.WriteLine();
            }
        }

        private static void ResultingOutput(object input)
        {
            if (input is IEnumerable<Phone>)
                Output2((IEnumerable<Phone>)input);
           
            else
                if(input is IQueryable<Phone>)
                Output((IQueryable<Phone>)input);
        }
        private static void Output2(IEnumerable<Phone> phones2)
        {
            foreach (var item in phones2)
            {
                Console.WriteLine($"{ item.Id}.{item.Name} - {item.Price}");
            }
        }

        private static void ShowDetails(object phones1)
        {
            Console.WriteLine($"Query:{Environment.NewLine} {phones1}");
            Console.WriteLine();
            ResultingOutput(phones1);
            Console.WriteLine(new string('-', 40));
        }
    }
}
