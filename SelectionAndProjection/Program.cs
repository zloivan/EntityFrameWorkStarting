using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
namespace SelectionAndProjection
{
    class Program
    {
        
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
                var samsungPhones = db.Phones.Where(p => p.Company.Name == "Samsung");
                foreach (Phone phone in samsungPhones)
                {
                    ShowPhoneInfo(phone);
                }

                Console.WriteLine( new string('-',40));

                Phone phone1 = db.Phones.Find(3);
                ShowPhoneInfo(phone1);

                Console.WriteLine(new string('-', 40));
                //В случае некоректного запроса вернет null, к примеру при выборе Id=5. 
                Phone phone2 = db.Phones.FirstOrDefault(p => p.Id == 4);
                if (phone2 != null)
                {
                    ShowPhoneInfo(phone2);
                }
                Console.WriteLine(new string('-', 40));
                //В случае некорректного запроса, выкенет исключение, null не вернет.
                Phone phone3 = db.Phones.First(p => p.Id == 4);
                if (phone3 != null)
                    ShowPhoneInfo(phone3);
                Console.WriteLine(new string('-', 40));

                var phone4 = db.Phones.Select(p => new { p.Name, p.Price, Company = p.Company.Name });

                foreach (var item in phone4)
                {
                    Console.WriteLine($"{item.Name} \t\tby {item.Company} - {item.Price}");
                }


                Console.WriteLine(new string('-', 40));

                var phone5 = db.Phones.Select(p => new Model {Name=p.Name,Price=p.Price,Company=p.Company.Name });

                foreach (var item in phone5)
                {
                    Console.WriteLine($"{item.Name} by {item.Company} - {item.Price}");
                }
                Console.WriteLine(new string('-', 40));
            }
        }
        class Model
        {
            public string Name { get; set; }
            public string Company { get; set; }
            public int Price { get; set; }
        }
        private static void ShowPhoneInfo(Phone phone)
        {
            Console.WriteLine($"{phone.Id}.{phone.Name} - {phone.Price}");
        }
    }
}
