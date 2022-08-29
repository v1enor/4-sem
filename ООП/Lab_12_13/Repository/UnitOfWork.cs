//позволяет упростить работу с различными репозиториями 
// и дает уверенность, что все репозитории будут использовать один и тот же контекст данных
using laba12.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12.Repository
{
    public class UnitOfWork : IDisposable
    {
        private MarketContext context = new MarketContext();
        private ProductRepository productRepository;
        private ShoppingCartRepository shoppingCartRepository;

        public ProductRepository Product
        {
            get
            {
                if (productRepository == null)
                {
                    productRepository = new ProductRepository(context);
                }
                    
                return productRepository;
            }
        }
        public ShoppingCartRepository ShoppingCart
        {
            get
            {
                if (shoppingCartRepository == null)
                    shoppingCartRepository = new ShoppingCartRepository(context);
                return shoppingCartRepository;
            }
        }
        public void Save()
        {
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Dispose();
        }

    }
}
