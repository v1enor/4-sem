using laba12.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba12.Repository
{
    public class ProductRepository : IRepository<Product>
    {
        private MarketContext context;
        public ProductRepository(MarketContext context)
        {
            this.context = context;
        }

        public IEnumerable<Product> GetAll()
        {
            return context.Product;
        }

        public Product Get(int id)
        {
            return context.Product.Find(id);
        }

        public Product GetByName(string name)
        {
            return context.Product.FirstOrDefault(x => x.Name == name);
        }

        public void Create(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public void Update(Product productOld, Product productNew)
        {
            var tmp = context.Product.FirstOrDefault(x => x.Id == productOld.Id);

            if (tmp != null)
            {
                tmp.Name = productNew.Name;
                tmp.Price = productNew.Price;
                tmp.Count = productNew.Count;
            }
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            Product product = context.Product.Find(id);
            if (product != null)
                context.Product.Remove(product);
            context.SaveChanges();
        }
    }
}
