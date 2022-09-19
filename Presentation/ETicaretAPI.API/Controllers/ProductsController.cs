using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Application.ViewModels.Products;
using ETicaretAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _prodctWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
       
        public ProductsController(IProductWriteRepository prodctWriteRepository, IProductReadRepository productReadRepository, 
            IOrderWriteRepository orderWriteRepository, ICustomerWriteRepository customerWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _prodctWriteRepository = prodctWriteRepository;
            _productReadRepository = productReadRepository;
          
        }
        [HttpGet]
        public async Task<IActionResult> Get()
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

            //Order order= await _orderReadRepository.GetByIdAsync("8ba5ff11-8ae6-4879-81ef-dbfbc45d4c37");
            // order.Address = "İstanbul";
            // await _prodctWriteRepository.SaveAsync();

            

            return Ok(_productReadRepository.GetAll(false));

             
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            return Ok(await _productReadRepository.GetByIdAsync(id,false));
        }


        [HttpPost]
        public async Task<IActionResult> Post(VM_Create_Product product)
        {
            if (ModelState.IsValid)
            {

            }

           await _prodctWriteRepository.AddAsync(new Product 
            {
                Name=product.Name,Price=product.Price,Stock=product.Stock
            });
            await _prodctWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);

        }


        [HttpPut]
        public async Task<IActionResult> Put(VM_Update_Products model)
        {
          Product product= await _productReadRepository.GetByIdAsync(model.Id);
            product.Stock = model.Stock;
            product.Price = model.Price;
            product.Name = model.Name;

       
            await _prodctWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _prodctWriteRepository.RemoveAsync(id);
            await _prodctWriteRepository.SaveAsync();
            return Ok();
        }







    }
}
