using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContext;
namespace Join
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataModel db = new DataModel())
            {
                var phones = db.Companies.Join(db.Phones,
                    c=> c.Name, //Берем свойство из первой последовательности
                    p=> p.Company.Name, //Свойство из второй
                    (comp,phon)=> new //здесь будет анонимный тип, в который попадают элементы наших последовательностей
                    //у которых совпадают свойства из пукнтов выше.
                    {
                        phon.Id,
                        phon.Name,
                        Company = comp.Name,
                        phon.Price
                    }
                    );

                foreach (var item in phones)
                {
                    Console.WriteLine($"{item.Id}.{item.Name} by {item.Company} - {item.Price}");
                }


                Console.WriteLine(new string('-',40));
            }

        }
    }
}
