using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
namespace SetOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
                var ph = db.Phones.Include("Company")
                    .Where(p => p.Price < 10000)
                    .Union(db.Phones.Where(p => p.Name.Contains("Samsung")));

                foreach (Phone phone in ph)
                {
                    ShowPhoneInfo(phone);
                }
                Console.WriteLine(new string('-', 40));

                var result = db.Phones.Select(p => new { Name = p.Name })
                    .Union(db.Companies.Select(c => new { Name = c.Name }));

                foreach (var item in result)
                {
                    Console.WriteLine($"{item.Name}");
                }
                Console.WriteLine(new string('-', 40));
                //Пересечения: {1,2,3}{2,4,6}=>{2}
                var intersected = db.Phones.Include("Company")
                    .Where(p => p.Price < 25000)//{все кроме iphone 7s }
                    .Intersect(db.Phones.Where(p => p.Name.Contains("Samsung") || p.Name.Contains("Nokia")));//{только самсунги}

                foreach (var item in intersected)
                {
                    ShowPhoneInfo(item);
                }
                Console.WriteLine(new string('-', 40));
                ShowAllPhones(db);
                //Исключение: {1,2,3,4,5}{2,3,4}=>{1,5}
                var except = db.Phones.Include("Company")
                    .Where(p => p.Price > 5000 && p.Price < 25000)
                    .Except(db.Phones.Where(p => p.Name.Contains("Nokia")));
                Console.WriteLine("--Пересечение телефонов с ценой от 15000 до 25000 и телефонов Nokia--");
                foreach (var item in except)
                {
                    ShowPhoneInfo(item);
                }


                Console.WriteLine(new string('-', 40));
            }
        }

        private static void ShowAllPhones(DataModel db)
        {
            foreach (var item in db.Phones.Include("Company"))
            {
                ShowPhoneInfo(item);
            }
        }

        private static void ShowPhoneInfo(Phone phone)
        {
            Console.WriteLine($"{phone.Id}.{phone.Name}({phone.Company.Name}) - {phone.Price}");
        }
    }
}
