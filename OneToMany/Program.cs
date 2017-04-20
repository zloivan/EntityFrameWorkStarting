using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToMany
{
    class Program
    {
        static void Main(string[] args)
        {

            Database.SetInitializer(new DropCreateDatabaseAlways<OneToManyContext>());

            using (OneToManyContext db = new OneToManyContext())
            {
                Product product1 = new Product {Name="Спички", Price = 30 };
                Product product2 = new Product { Name = "Сигареты", Price = 45 };
                Product product3 = new Product { Name = "Зажигалка", Price = 50 };
                Product product4 = new Product { Name = "Прикуриватель", Price = 15 };
                Product product5 = new Product { Name = "Табак", Price = 25 };

                db.Products.AddRange(new List<Product> {product1,product2,product3,product4,product5 });

                db.SaveChanges();

                var products = db.Products.ToList();

                foreach (var item in products)
                {
                    Console.WriteLine("{0}.{1} - ({2}) - {3}",
                        item.Id,
                        item.Name,
                        item.Price,
                        item.Order!=null?item.Order.Customer:"No customer"
                        );
                }
                Console.WriteLine(new string('-',40));

                Console.ReadKey();

                
                Order order1 = new Order { Customer = "Ivan", Quantity = 3, Product = new List<Product> {product1,product3,product5}};
                Order order2 = new Order {Customer="Lena",Quantity=2, Product= new List<Product> {product4,product2 } };

                db.Orders.AddRange(new List<Order> {order1,order2});

                db.SaveChanges();
                foreach (var item in products)
                {
                    Console.WriteLine("{0}.{1} - ({2}) - {3}",
                        item.Id,
                        item.Name,
                        item.Price,
                        item.Order != null ? item.Order.Customer : "No customer"
                        );
                }
                Console.WriteLine(new string('-', 40));

                Console.ReadKey();

                var orders = db.Orders.ToList();
                //Order:
                foreach (var OrderItem in orders)
                {
                    Console.WriteLine("{0}.{1}",
                        OrderItem.Id,
                        OrderItem.Customer
                        );
                    if (OrderItem.Product == null) continue;
                    foreach (var productItem in OrderItem.Product)
                    {
                        Console.WriteLine("Продукт:{0}({1})*{2}={3}",productItem.Name,productItem.Price,OrderItem.Quantity,OrderItem.Quantity*productItem.Price);
                    }

                }

            }
        }
    }
}
