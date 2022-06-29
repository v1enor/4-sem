namespace laba12.Model
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    public class MarketContext : DbContext
    {
        public MarketContext()
            : base("name=MarketContext")
        {
        }

        public DbSet<Product> Product { get; set; } //objects
        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        public class MarketInitializer
            : DropCreateDatabaseAlways<MarketContext>
        {
            protected override void Seed(MarketContext context)
            {
                List<Product> stores = new List<Product>
            {
                new Product("Сыр", 20, 5),
                new Product("Молоко", 10, 10),
                new Product("Батон", 8, 7),
                new Product("Курица", 50, 4),
                new Product("Рыба", 60, 8),
                new Product("Салат", 15, 3),
                new Product("Шоколад", 15, 10),
                new Product("Печенье", 18, 15),
                new Product("Сметана", 12, 18),
                new Product("Вода", 5, 6),
            };

                foreach (Product store in stores)
                    context.Product.Add(store);

                context.SaveChanges();
                base.Seed(context);
            }
        }
        static MarketContext()
        {
            Database.SetInitializer<MarketContext>(new MarketInitializer());
        }
    }
}