using PetShopProject.UI.Services;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NUnit.Framework;
using PetShopProject.Api.Data;
using PetShopProject.Api.Repository;
using System.Net.Http.Json;
using PetShopProject.Test.Helper;
using PetShopProject.Test;
namespace PetShopProject.IntegrationTest.Tests
{
    public class ProductIntegrationTests : BaseTest
    {
        private IProductRepository _productRepository;

        [SetUp]
        public void Setup()
        {
            _productRepository = GetService<IProductRepository>();
        }

        [Test]
        public async Task GetAllProducts_ShouldReturnConsistentDataBetweenApiAndDatabase()
        {
            // Arrange: Create a client to make HTTP requests
            var webClient = _factory.CreateClient();

            // Act: Send a request to the API to retrieve all products
            var response = await webClient.GetAsync(Urls.GetAllProducts);
            var apiProducts = await response.Content.ReadFromJsonAsync<List<Product>>();

            // Assert: Check that the API response is not null and matches the database data
            apiProducts.Should().NotBeNull();
            var ormProducts = _productRepository.GetAllProducts();
            apiProducts[0].name.Should().Be(ormProducts[0].name);
        }

        [Test]
        public async Task AllProductApiEndpoints_ShouldBeAccessible()
        {
            // Arrange: Create an HTTP client
            var webClient = _factory.CreateClient();

            // Act & Assert

            // Test the GET /ProductApi/Get endpoint
            var getAllResponse = await webClient.GetAsync("/ProductApi/Get");
            getAllResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Test the GET /ProductApi/GetById/{id} endpoint with a sample ID (assuming ID 1 exists)
            var getByIdResponse = await webClient.GetAsync("/ProductApi/GetById/1");
            getByIdResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Test the POST /ProductApi/Create endpoint
            var createProduct = new Product
            {
                datetime = DateTime.Now,
                description = "Sample product for testing",
                name = "TestProduct",
                price = 10m,
                productType = ProductType.Type4
            };
            var createResponse = await webClient.PostAsJsonAsync("/ProductApi/Create", createProduct);
            createResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Test the PUT /ProductApi/Update endpoint
            createProduct.description = "Updated description";
            var updateResponse = await webClient.PutAsJsonAsync("/ProductApi/Update", createProduct);
            updateResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

            // Test the DELETE /ProductApi/Delete/{id} endpoint with the ID of the created product (e.g., ID 1)
            var deleteResponse = await webClient.DeleteAsync("/ProductApi/Delete/1");
            deleteResponse.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
        }



    }
}

