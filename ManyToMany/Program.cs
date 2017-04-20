using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManyToMany
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<ManyToManyContext>());

            using (ManyToManyContext db = new ManyToManyContext())
            {
                Product product1 = new Product {Name="Колготки",Price=15 };
                Product product2 = new Product { Name = "Майка", Price = 20 };
                Product product3 = new Product { Name = "Стринги", Price = 10 };
                Product product4 = new Product { Name = "Ботинки", Price = 100 };

                db.Products.AddRange(new List<Product> {product1,product2,product3,product4 });

                db.SaveChanges();

                Order order1 = new Order {Customer="Иван",Quantety=2};
                order1.Product.Add(product2);
                order1.Product.Add(product4);
                Order order2 = new Order { Customer = "Лена", Quantety = 1 };
                order2.Product.Add(product1);
                order2.Product.Add(product3);
                Order order3 = new Order { Customer = "Мама", Quantety = 1 };
                order3.Product.Add(product1);
                order3.Product.Add(product3);
                order3.Product.Add(product2);
                order3.Product.Add(product4);
                db.Orders.AddRange(new List<Order> {order1,order2,order3});

                db.SaveChanges();


                foreach (var OrderItem in db.Orders.Include(p=>p.Product))
                {
                    Console.WriteLine("{1}.{0}",OrderItem.Customer,OrderItem.Id);
                    if (OrderItem.Product == null) continue;
                    foreach (var prodItem in OrderItem.Product)
                    {
                        Console.WriteLine("Продукт:{0} \t  {1}-({2})={3} ",prodItem.Name,prodItem.Price,OrderItem.Quantety,prodItem.Price*OrderItem.Quantety); 
                    }
                }
            }
        }
    }
}
