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
        readonly private IOrderReadRepository _orderReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        public ProductsController(IProductWriteRepository prodctWriteRepository, IProductReadRepository productReadRepository, 
            IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _prodctWriteRepository = prodctWriteRepository;
            _productReadRepository = productReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _customerWriteRepository = customerWriteRepository;
            _orderReadRepository = orderReadRepository;
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


            //await _prodctWriteRepository.AddAsync(new Product { Name = "c Product", Price = 1.500F, Stock = 10 });

            // await _prodctWriteRepository.SaveAsync();
            // var customerId=Guid.NewGuid();
            //  _customerWriteRepository.AddAsync(new Customer { Id = customerId, Name = "Muidiin" });
            //await _orderWriteRepository.AddAsync (new Order { Address="ankara, çankaya",Description="bla bla",CustomerId=customerId});
            //  await _orderWriteRepository.AddAsync(new Order { Address = "ankara, pursaklar", Description = "bla bla 2", CustomerId = customerId});
            //  await _orderWriteRepository.SaveAsync();

           Order order= await _orderReadRepository.GetByIdAsync("8ba5ff11-8ae6-4879-81ef-dbfbc45d4c37");
            order.Address = "İstanbul";
            await _prodctWriteRepository.SaveAsync();

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            Product product= await _productReadRepository.GetByIdAsync(id);
            return Ok(product);
        }

    }
}
