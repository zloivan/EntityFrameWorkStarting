using System.Collections.Generic;

namespace OneToMany
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public int Quantity { get; set; }
        public List<Product> Product { get; set; }

    }
}