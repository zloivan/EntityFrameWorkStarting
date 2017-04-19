using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFraimwork
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int menuinput =0;
            do
            {
                Console.WriteLine("1) Исправить? 2) Добавить? 3) Ппказать все 4)Удалить? 5) Удалить несколько?");
                 menuinput =Convert.ToInt32( Console.ReadLine());
                
                Menu(menuinput);
            } while (menuinput == 1 || menuinput==2 || menuinput==3|| menuinput==4 || menuinput == 5);
            

            


        }
        public static void Delete(int id)
        {
            using (MyModel db = new MyModel())
            {
                MyEntity deleteEntity = db.MyEntities.Find(id);
                if (deleteEntity == null) return;
                db.MyEntities.Remove(deleteEntity);
                db.SaveChanges();
            }

        }

        public static void Add()
        {
            MyEntity newEntity = new MyEntity();
            Console.WriteLine("Имя: ");
            newEntity.FirstName = Console.ReadLine();
            Console.WriteLine("Фамилия: ");
            newEntity.LastName = Console.ReadLine();
            Console.WriteLine("Возраст: ");
            newEntity.Age = Convert.ToInt32(Console.ReadLine()); 
            using (MyModel db = new MyModel())
            {
                if (newEntity == null)
                {
                    Console.WriteLine("Entity is empty");
                    return;
                }
                db.MyEntities.Add(newEntity);
                db.SaveChanges();
            }
        }

        public static void ShowAll()
        {
            
            using (MyModel db = new MyModel())
            {
                var EntityList = db.MyEntities.ToList();
                foreach (var item in EntityList)
                {
                    Console.WriteLine($"{item.Id}.{item.FirstName}-{item.LastName} \t {item.Age}");
                }
                    
            }
        }

        public static void Edit()
        {
            using (MyModel db = new MyModel())
            {
                Console.WriteLine("Выберите Id челловека\n");
                int id = Convert.ToInt32(Console.ReadLine());
                var editentity =db.MyEntities.Find(id);
                
                
                
                Console.WriteLine("Введите изменения Имени\n");
                string name = Console.ReadLine();
                Console.WriteLine("Введите изменения фамилии\n");
                string SecondName = Console.ReadLine();
                Console.WriteLine("Введите изменения ввозраста\n");
                int ageChange = Convert.ToInt32(Console.ReadLine());

                editentity.FirstName = name;
                editentity.LastName = SecondName;
                editentity.Age = ageChange;
                db.SaveChanges();
            }
        }

        public static void DeleteRange(string array)
        {
            
            var myarray =array.Split(' ');
            
            foreach (var item in myarray)
            {

                Delete(Convert.ToInt32(item));

            }
            
        }

        public static void Menu(int input)
        {
            
                switch (input)
                {
                    case 1: Edit(); break;
                    case 2: Add(); break;
                    case 3: ShowAll(); break;
                    case 4:Console.WriteLine("Удалить кого? "); Delete(Convert.ToInt32(Console.ReadLine()));break;
                case 5: Console.WriteLine("Введите список id на удаление через пробел."); DeleteRange(Console.ReadLine()); break;
                    
                default: break;
                }
            
                
        }

    }
}
