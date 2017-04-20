using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqToEntityes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> empolyees = new List<Person>
            {
                new Person{FirstName="Ivan",LastName="Khamichkou",Salary=1000m,StartDate=DateTime.Parse("15/05/1990") },
                new Person{FirstName="Gena",LastName="Khamichkou",Salary=1500m,StartDate=DateTime.Parse("15/02/1965") },
                new Person{FirstName="Elena",LastName="Khamichkoua",Salary=1200m,StartDate=DateTime.Parse("15/04/1995") },
                new Person{FirstName="Masha",LastName="Khamichkoua",Salary=200m,StartDate=DateTime.Parse("01/12/1995") },
            };
            //Варинт в уроке
            var query = Enumerable.Select(
                Enumerable.Where(empolyees, emp => emp.Salary > 1000m), 
                emp => new {LastName=emp.LastName,FirstName=emp.FirstName,Salary=emp.Salary }
                );
            //Мой вариант
            var query2 = empolyees.
                Where(e => e.Salary > 1000m).
                Select(e => new {LastName=e.LastName,FirstName=e.FirstName,Salary=e.Salary });
            foreach (var item in query)
            {
                Console.WriteLine("Сотрудник:{0} {1} - {2} ",item.LastName,item.FirstName,item.Salary);
            }
            Console.WriteLine(new string('-',40));
            foreach (var item in query2)
            {
                Console.WriteLine("Сотрудник:{0} {1} - {2} ", item.LastName, item.FirstName, item.Salary);
            }
        }
    }
}
