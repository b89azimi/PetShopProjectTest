using PetShopProject.Api.Data;

namespace PetShopProject.Api.Repository
{
    public interface IProductRepository
    {
        public List<Product> GetAllProducts();
        public Product GetProductById(int id);
        public void CreateProduct(Product product);
        public void UpdateProduct(Product product);
        public void DeleteProduct(int id);

    }
}
