using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneToOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<OneToOne>());

            using(OneToOne db= new OneToOne())
            {
                Product product1 = new Product {Name="Coca Cola",Price=20 };
                Product product2 = new Product {Name="Pepsi",Price=15 };


                db.Products.Add(product1);
                db.Products.Add(product2);

                db.SaveChanges();

                Order order1 = new Order {Customer="Alex",Quantity=3,Product=product1 };
                Order order2 = new Order { Customer = "Nazar", Quantity = 2, Product = product2 };
                Order order3 = new Order { Customer = "Vitalii", Quantity = 1, Product = product2 };
                db.Orders.AddRange(new List<Order> {order1,order2, order3 });
                db.SaveChanges();
                var orders = db.Orders.ToList();

                foreach (var item in orders)
                {
                    Console.WriteLine("{0}.{1} -> ({2}) Цена за шт: {3}$ - {4} шт",
                        item.Id,
                        item.Customer,
                        item.Product!= null? item.Product.Name : "X",
                        item.Product!=null? Convert.ToString(item.Product.Price):"X",
                        item.Quantity);
                }
            }
        }
    }
}
