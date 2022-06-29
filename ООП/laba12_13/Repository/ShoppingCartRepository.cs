using laba12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12.Repository
{
    public class ShoppingCartRepository : IRepository<ShoppingCart>
    {
        private MarketContext context;
        public ShoppingCartRepository(MarketContext context)
        {
            this.context = context;
        }

        public IEnumerable<ShoppingCart> GetAll()
        {
            return context.ShoppingCart;
        }

        public ShoppingCart Get(int id)
        {
            return context.ShoppingCart.Find(id);
        }

        public void Create(ShoppingCart shoppingCart)
        {
            context.ShoppingCart.Add(shoppingCart);
            context.SaveChanges();
        }

        public void Update(ShoppingCart shoppingCartOld, ShoppingCart shoppingCartNew)
        {
            var tmp = context.ShoppingCart.FirstOrDefault(x => x.Id == shoppingCartOld.Id);

            if (tmp != null)
            {
                tmp.Count = shoppingCartNew.Count;
                tmp.ProductId = shoppingCartNew.ProductId;
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            ShoppingCart shoppingCart = context.ShoppingCart.Find(id);
            if (shoppingCart != null)
                context.ShoppingCart.Remove(shoppingCart);
            context.SaveChanges();
        }

        public ShoppingCart GetByProductId(int productId)
        {
            return context.ShoppingCart.FirstOrDefault(x => x.ProductId == productId);
        }

    }
}
