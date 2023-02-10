using e_shop_backend.Models.ProductModel;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using System.Xml.Linq;

namespace e_shop_backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/<ProductsController>
        [HttpGet("/products/all")]
        public async Task<ActionResult> GetProducts()
        {
            var products = await _unitOfWork.Products.GetAll();

            _unitOfWork.Dispose();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetProductById(Guid id)
        {
            return Ok(await _unitOfWork.Products.GetByID(id));
        }

        [HttpPost("all")]
        public async Task<ActionResult> GetProductsByParams([FromBody] GetProductRequest req)
        {
            if(ModelState.IsValid)
            {
                var response = await _unitOfWork.Products.GetAllWithQuery(req);

                _unitOfWork.Dispose();

                return Ok(response);
            }
            return BadRequest();
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProductDTO req)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Products.AddEntity((new Product
                {
                    id = Guid.NewGuid(),
                    name = req.name,
                    isActive = true,
                    price = req.price,
                    quantity = req.quantity,
                    productionDate = req.productionDate,
                    expiryDate = req.expiryDate,
                    category = req.category,
                    storageLocation = req.storageLocation,
                }));
                _unitOfWork.Complete();
                _unitOfWork.Dispose();
                

                return Ok((new Response<Product>
                {
                    Data = new List<Product>(),
                    IsSuccess = true,
                    message = "Successfull Operation",
                }));
            }

            return BadRequest((new Response<Product>
            {
                Data = new List<Product>(),
                IsSuccess = false,
                message = "incomplete object Operation",
            }));
        }

        // PUT api/<ProductsController>/5
        [HttpPut]
        public async Task<ActionResult> Put([FromBody] Product req)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Products.UpdateProduct(req);

                _unitOfWork.Complete();
                _unitOfWork.Dispose();

                return Ok((new Response<Product>
                {
                    Data = new List<Product>(),
                    IsSuccess = true,
                    message = "Successfull Operation",
                }));
            }

            return BadRequest((new Response<Product>
            {
                Data = new List<Product>(),
                IsSuccess = false,
                message = "incomplete object Operation",
            }));
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            bool result = _unitOfWork.Products.Remove(id);

            if (result == true)
            {
                _unitOfWork.Complete();
                _unitOfWork.Dispose();

                return Ok((new Response<Product>
                {
                    Data = new List<Product>(),
                    IsSuccess = true,
                    message = "Successfull Operation",
                }));
            }

            return BadRequest((new Response<Product>
            {
                Data = new List<Product>(),
                IsSuccess = false,
                message = "Bad object Operation",
            }));
        }
    }
}
