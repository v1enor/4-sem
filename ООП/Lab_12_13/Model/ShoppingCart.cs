using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace laba12.Model
{
    public class ShoppingCart
    {
        public int Id { get; set; }

        public int? ProductId { get; set; }
         
        public int Count { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        public ShoppingCart()
        { }

        public ShoppingCart(int count, int? product)
        {
            Count = count;
            ProductId = product;
        }
    }
}
