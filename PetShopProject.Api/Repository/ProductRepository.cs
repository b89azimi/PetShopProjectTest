using PetShopProject.Api.Data;

namespace PetShopProject.Api.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDbContext _productDbContext;
        public ProductRepository(ProductDbContext productDbContext)
        {
            _productDbContext = productDbContext;
        }

        public void CreateProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            if (product.price < 0)
            {
                throw new ArgumentException("Price must be a positive value.", nameof(product));
            }

            _productDbContext.products.Add(product);
            _productDbContext.SaveChanges();
        }


        public void DeleteProduct(int id)
        {
            var product = _productDbContext.products.FirstOrDefault(p => p.id == id);
            _productDbContext.products.Remove(product);
            _productDbContext.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return _productDbContext.products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _productDbContext.products.FirstOrDefault(p => p.id == id);

        }

        public void UpdateProduct(Product product)
        {
            if (product != null)
            {
                _productDbContext.products.Update(product);
                _productDbContext.SaveChanges();
            }
        }
    }
}
