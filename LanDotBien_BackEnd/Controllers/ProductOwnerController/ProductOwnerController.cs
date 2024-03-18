using System.Net;
using LanVar.Core.Entity;
using LanVar.DTO.DTO.request;
using LanVar.DTO.DTO.response;
using LanVar.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tools.Tools;

namespace LanDotBien_BackEnd.Controllers.ProductOwnerController
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductOwnerController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductOwnerController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductOwnerController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ProductOwnerController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductOwnerController>
        /*[HttpPost("CreateProduct"), Authorize]*/
        [HttpPost("CreateProduct")]
        public async Task<IActionResult> Post(CreateProductDTORequest createProductDtoRequest)
        {
            try
            {
                var productCreate = await _productService.CreateProduct(createProductDtoRequest);
                var response = new ApiResponse<ProductDTOResponse>(productCreate, HttpStatusCode.OK, "Product add success");
                return Ok(response); // Trả về kết quả thành công với dữ liệu UserPermission đã thêm
            }
            catch (CustomException.InvalidDataException ex)
            {
                var response = new ApiResponse<Package>(HttpStatusCode.Conflict, ex.Message);
                return BadRequest(response); // Trả về lỗi 400 Bad Request với thông báo lỗi
            }
           
        }

        // PUT api/<ProductOwnerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductOwnerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}