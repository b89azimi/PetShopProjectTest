using Microsoft.AspNetCore.Mvc;
using PetShopProject.Api.Data;
using PetShopProject.Api.Repository;

namespace PetShopProject.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductApiController : ControllerBase
    {
        private readonly IProductRepository _iproductRepository;
        public ProductApiController(IProductRepository productRepository)
        {
            _iproductRepository = productRepository;
        }
        [HttpGet]
        [Route("/[controller]/[action]")]
        public ActionResult<IList<Product>> Get()
        {
            return _iproductRepository.GetAllProducts();
        }
        [HttpGet]
        [Route("/[controller]/[action]/{id}")]
        public ActionResult<Product> GetById(int id)
        {
            return _iproductRepository.GetProductById(id);
        }
        [HttpPost]
        [Route("/[controller]/[action]")]
        public void Create(Product product)
        {
            _iproductRepository.CreateProduct(product);
        }
        [HttpPut]
        [Route("/[controller]/[action]")]
        public void Update(Product product)
        {
            _iproductRepository.UpdateProduct(product);
        }
        [HttpDelete]
        [Route("/[controller]/[action]/{id}")]
        public void Delete(int id)
        {
            _iproductRepository.DeleteProduct(id);
        }
    }
}