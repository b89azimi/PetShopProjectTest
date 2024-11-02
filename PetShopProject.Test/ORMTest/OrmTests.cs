using FluentAssertions;
using NUnit.Framework;
using PetShopProject.Api.Data;
using PetShopProject.Api.Repository;
using PetShopProject.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Test.ORMTest
{
    public class OrmTests : StartUp
    {
        private IProductRepository _productRepository;
        [SetUp]
        public void Setup()
        {
            _productRepository = GetService<IProductRepository>();
        }
        [Test]
        public async Task GetAllProducts_ShouldReturnNonNullCollection()
        {
            // Arrange & Act: Retrieve all products from the repository
            var products = _productRepository.GetAllProducts();

            // Assert: Check that the collection of products is not null
            Assert.That(products, Is.Not.Null);
        }

        [Test]
        public async Task CreateUpdateDeleteProduct_ShouldPerformCrudOperationsCorrectly()
        {
            // Arrange: Create a new product to test CRUD operations
            var newProduct = new Product()
            {
                datetime = DateTime.Now,
                description = "Sample Description",
                name = "PNew1",
                price = 1m,
                productType = ProductType.Type1
            };

            // Act & Assert: Verify product count before and after adding a new product
            var allProducts = _productRepository.GetAllProducts();
            int initialProductCount = allProducts.Count;
            allProducts.Count.Should().Be(initialProductCount);

            _productRepository.CreateProduct(newProduct);
            allProducts = _productRepository.GetAllProducts();
            allProducts.Count.Should().Be(initialProductCount + 1);

            // Act & Assert: Update the product's name and verify the changes were saved
            var testProduct = allProducts.FirstOrDefault(x => x.name == newProduct.name);
            var updatedProductName = "New Name";
            testProduct.name = updatedProductName;
            _productRepository.UpdateProduct(testProduct);
            allProducts = _productRepository.GetAllProducts();
            testProduct = allProducts.FirstOrDefault(x => x.name == updatedProductName);

            // Act & Assert: Delete the product and confirm the product count returns to the initial value
            _productRepository.DeleteProduct(testProduct.id);
            allProducts = _productRepository.GetAllProducts();
            allProducts.Count.Should().Be(initialProductCount);
        }

        [Test]
        public void CreateProduct_WithNegativePrice_ShouldThrowException()
        {
            // Arrange: Create a new product with a negative price
            var invalidProduct = new Product()
            {
                datetime = DateTime.Now,
                description = "Invalid product with negative price",
                name = "InvalidProduct",
                price = -5m,  // Negative price
                productType = ProductType.Type1
            };

            // Act & Assert: Verify that an exception is thrown when trying to save a product with a negative price
            Action act = () => _productRepository.CreateProduct(invalidProduct);

            // Depending on your implementation, replace ArgumentException with the specific exception type you expect
            act.Should().Throw<ArgumentException>()
                .WithMessage("Price must be a positive value*"); // Customize the message based on your validation
        }



    }
}
