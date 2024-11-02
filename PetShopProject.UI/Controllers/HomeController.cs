using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PetShopProject.UI.Models;
using PetShopProject.UI.Services;
using System.Diagnostics;

namespace PetShopProject.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IApiHelper _apiHelper;

        public HomeController(ILogger<HomeController> logger, IApiHelper apiHelper)
        {
            _apiHelper = apiHelper;

            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Products()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://localhost:7206");
            var result = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, "/ProductApi/Get"));
            var model = JsonConvert.DeserializeObject<List<HomeProductModel>>(await result.Content.ReadAsStringAsync());
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(HomeProductModel homeProductModel)
        {
            var model = new HomeProductModel()
            {
                id = homeProductModel.id,
                datetime = homeProductModel.datetime,
                description = homeProductModel.description,
                name = homeProductModel.name,
                price = homeProductModel.price,
                productType = homeProductModel.productType
            };
            var response = await _apiHelper.RestsharpAsync<object>(ApiConfig.BaseUrl, "ProductApi/Create", RestSharp.Method.Post, model);
            if (!response.IsSuccessStatusCode)
                return NotFound();

            return RedirectToAction("Products");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _apiHelper.RestsharpAsync<HomeProductModel>(ApiConfig.BaseUrl, $"ProductApi/GetById/{id}", RestSharp.Method.Get);
            if (!response.IsSuccessStatusCode || response == null)
                return NotFound();

            return View(response.Data);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(HomeProductModel homeProductModel)
        {
            var model = new HomeProductModel()
            {
                id = homeProductModel.id,
                datetime = homeProductModel.datetime,
                description = homeProductModel.description,
                name = homeProductModel.name,
                price = homeProductModel.price,
                productType = homeProductModel.productType
            };

            var response = await _apiHelper.RestsharpAsync<HomeProductModel>(ApiConfig.BaseUrl, $"ProductApi/Update", RestSharp.Method.Put, model);

            return RedirectToAction("Products");
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _apiHelper.RestsharpAsync<object>(ApiConfig.BaseUrl, $"ProductApi/Delete/{id}", RestSharp.Method.Delete);

            return RedirectToAction("Products");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var response = await _apiHelper.RestsharpAsync<HomeProductModel>(ApiConfig.BaseUrl, $"ProductApi/GetById/{id}", RestSharp.Method.Get);


            return View(response.Data);
        }

    }
}