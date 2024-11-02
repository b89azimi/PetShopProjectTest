using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NUnit.Framework;
using PetShopProject.Api.Data;
using PetShopProject.Api.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetShopProject.Test
{
    public class BaseTest
    {
        //  private IApiHelper _apiHelper;
        public static WebApplicationFactory<Program> _factory;
        private ServiceProvider _serviceProvider;
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _factory = new WebApplicationFactory<Program>().WithWebHostBuilder(builder =>
            {
                builder.ConfigureTestServices(services =>
                {
                    services.RemoveAll(typeof(DbContextOptions<ProductDbContext>));
                    services.AddDbContext<ProductDbContext>(option =>
                    {
                        option.UseInMemoryDatabase("InMemoryProductApi");
                    });
                    services.AddTransient<IProductRepository, ProductRepository>();
                    _serviceProvider = services.BuildServiceProvider();
                });
            });
        }
        protected T GetService<T>() => _serviceProvider.GetRequiredService<T>();
        [OneTimeTearDown]
        public void Teardown() => _factory.Dispose();


        [SetUp]
        public void SetUp()
        {
            using (var scope = _factory.Services.CreateScope())
            {
                var scopeService = scope.ServiceProvider;
                var DbContext = scopeService.GetRequiredService<ProductDbContext>();
                try
                {
                    DbContext.Database.EnsureCreated();
                    DbContext.products.Add(new Product
                    {
                        name = "new1",
                        datetime = DateTime.Now,
                        description = "new description",
                        price = 200,
                        productType = ProductType.Type4
                    });
                    DbContext.SaveChanges();


                }
                catch
                {

                }
            }
            //  _apiHelper = GetService<IApiHelper>();
        }
    }
}
