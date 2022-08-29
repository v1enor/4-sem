using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12.Model
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Price { get; set; }

        public int Count { get; set; }

        public ICollection<ShoppingCart> ShoppingCart { get; set; }

        public Product()
        {
        }

        public Product(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }
    }
}
