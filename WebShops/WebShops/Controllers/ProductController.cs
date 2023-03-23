using Demo.DataBase.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebShop.Application.Catalog.Productt;
using WebShop.ViewModels.Catalog.Productt;

namespace WebShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _productService;
        private readonly IManageProductService _manageProductService;
        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _productService = publicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _productService.GetAll();
            return Ok(products);

        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublictProductPadingRequest request)
        {
            var products = await _productService.GetAllCategoryId(request);
            return Ok(products);
        }
        [HttpGet("productId")]
        public async Task<IActionResult> GetAllById(int productId)
        {
            var products = await _manageProductService.GetAllById(productId);
            if(products == null)
            {
                return BadRequest("CanNot find product");
            }

            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == null)
            {
                return BadRequest("Cannot Find product");
            }
            var product =  _manageProductService.GetAllById(productId);
            return CreatedAtAction(nameof(GetAllById), new {id=product}, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] ProductUpdateRequest request)
        {
            var affectedResust = await _manageProductService.Update(request);
            if (affectedResust == 0)
            {
                return BadRequest("Cannot Find product");
            }
            return Ok();
        }
        [HttpPut("Price/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromQuery]int Id,decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(Id,newPrice);
            if (isSuccessful)
            {
                return Ok();
            }
            return BadRequest("Cannot Find product");
        }
    }
}
