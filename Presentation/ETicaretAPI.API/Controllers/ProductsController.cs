using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _prodctWriteRepository;
        readonly private IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository prodctWriteRepository, IProductReadRepository productReadRepository)
        {
            _prodctWriteRepository = prodctWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async Task Get()
        {
            //await  _prodctWriteRepository.AddRangeAsync(new List<Product>{
            //      new Product{Id=Guid.NewGuid(),Name="Product 1", Price=100,CreatedTime=DateTime.UtcNow,Stock=10},
            //      new Product{Id=Guid.NewGuid(),Name="Product 2", Price=200,CreatedTime=DateTime.UtcNow,Stock=20},
            //      new Product{Id=Guid.NewGuid(),Name="Product 3", Price=300,CreatedTime=DateTime.UtcNow,Stock=130},

            //  });
            //await  _prodctWriteRepository.SaveAsync();

          Product p=  await _productReadRepository.GetByIdAsync("9e57045a-9a68-4cb3-a036-3b59f015aa08");
            p.Name = "Ahmet";
            _prodctWriteRepository.SaveAsync();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
