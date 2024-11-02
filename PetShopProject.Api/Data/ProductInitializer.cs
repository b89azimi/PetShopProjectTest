using Microsoft.EntityFrameworkCore;

namespace PetShopProject.Api.Data
{
    public class ProductInitializer
    {
        private readonly ModelBuilder _modelBuilder;
        public ProductInitializer(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
        }
        public void Seed()
        {
            _modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    id = 1,
                    name = "P1",
                    datetime = DateTime.Now,
                    description = "P1 description",
                    price = 300,
                    productType = ProductType.Type1
                },
                 new Product
                 {
                     id = 2,
                     name = "P2",
                     datetime = DateTime.Now,
                     description = "P2 description",
                     price = 400,
                     productType = ProductType.Type2
                 },
                  new Product
                  {
                      id = 3,
                      name = "P3",
                      datetime = DateTime.Now,
                      description = "P3 description",
                      price = 500,
                      productType = ProductType.Type3
                  },
                   new Product
                   {
                       id = 4,
                       name = "P4",
                       datetime = DateTime.Now,
                       description = "P4 description",
                       price = 600,
                       productType = ProductType.Type4
                   }

                );
        }

    }
}
