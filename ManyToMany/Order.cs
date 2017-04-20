using System.Collections.Generic;

namespace ManyToMany
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantety { get; set; }
        public List<Product> Product { get; set; }
        public Order()
        {
            Product = new List<Product>();
        }
    }
}