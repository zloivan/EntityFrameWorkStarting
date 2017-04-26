using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
                var phones = db.Phones.OrderBy(p=>p.Name);
                Console.WriteLine(phones);
                foreach (var item in phones)
                {
                    ShowPhoneInfo(item);
                }
                Console.WriteLine(new string('-', 40));
                var phoneAddition = db.Phones.OrderBy(p => p.Name).Select(p => p);
                Console.WriteLine(phoneAddition);
                foreach (var item in phoneAddition)
                {
                    ShowPhoneInfo(item);
                }
                Console.WriteLine(new string('-',40));

                var phoneDec = db.Phones.OrderByDescending(p => p.Name);
                foreach (var item in phoneDec)
                {
                    ShowPhoneInfo(item);
                }

                Console.WriteLine(new string('-', 40));

                var phoneMultiple = db.Phones.Select(p => new { p.Name, p.Price, Company = p.Company.Name })
                    .OrderBy(p => p.Price)
                    .ThenBy(p => p.Company);

                foreach (var item in phoneMultiple)
                {
                    Console.WriteLine($"{item.Name} by {item.Company} - {item.Price}");
                }

                Console.WriteLine(new string('-',30));

            }
        }

        private static void ShowPhoneInfo(Phone item)
        {
            Console.WriteLine($"{item.Id}.{item.Name} - {item.Price}");
        }
    }
}
