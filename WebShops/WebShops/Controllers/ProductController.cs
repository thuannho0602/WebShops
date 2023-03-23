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

        [HttpGet("{LanguageId}")]
        public async Task<IActionResult> Get(string languageId)
        {
            var products = await _productService.GetAll( languageId);
            return Ok(products);

        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublictProductPadingRequest request)
        {
            var products = await _productService.GetAllCategoryId(request);
            return Ok(products);
        }
        [HttpGet("{Id}/{languageId}")]
        public async Task<IActionResult> GetAllById(int productId,string languageId)
        {
            var products = await _manageProductService.GetAllById(productId,languageId);
            if (products == null)
            {
                return BadRequest("CanNot find product");
            }

            return Ok(products);

        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            var productId = await _manageProductService.Create(request);
            if (productId == null)
            {
                return BadRequest("Cannot Find product");
            }
            var product = _manageProductService.GetAllById(productId,request.LanguageId);
            return CreatedAtAction(nameof(GetAllById), new { id = product }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            var affectedResust = await _manageProductService.Update(request);
            if (affectedResust == 0)
            {
                return BadRequest("Cannot Find product");
            }
            return Ok();
        }
        [HttpPut("Price/{newPrice}")]
        public async Task<IActionResult> UpdatePrice([FromForm] int Id, decimal newPrice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(Id, newPrice);
            if (isSuccessful)
            {
                return Ok();
            }
            return BadRequest("Cannot Find product");
        }
        [HttpDelete("productId")]
        public async Task<IActionResult> Delete(int productId)
        {
            var deleteId=await _manageProductService.Delete(productId);
            if(deleteId == 0)
            {
                return BadRequest();
            }
            return Ok();
        }
    }
}
