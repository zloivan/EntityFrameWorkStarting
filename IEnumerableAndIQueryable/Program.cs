using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;

namespace IEnumerableAndIQueryable
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext.DataModel db = new DataModel())
            {
                IEnumerable<Phone> phone = db.Phones.ToList();
                phone = phone.Where(p=>p.Id>3);

                Console.WriteLine(phone);

                foreach (var item in phone)
                {
                    Console.WriteLine($"{item.Id}.{item.Name}");
                }

                Console.WriteLine(new string('-',40));

                IQueryable<Phone> phone1 = db.Phones;
                phone1=phone1.Where(p => p.Id > 3);

                Console.WriteLine(phone1);
                foreach (var item in phone1)
                {
                    Console.WriteLine($"{item.Id}.{item.Name}");
                }
            }
        }
    }
}
