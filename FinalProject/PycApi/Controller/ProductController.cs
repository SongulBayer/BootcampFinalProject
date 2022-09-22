using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Base;
using PycApi.Dto;
using PycApi.Service;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authorization;

namespace PycApi.Controllers
{
  
    [ApiController]
    [Route("api/nhb/[controller]")]

    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;


        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }
        //Only authorized users can access
        [Authorize]
        [HttpGet]
        public BaseResponse<IEnumerable<ProductDto>> GetAll()
        {
            var response = productService.GetAll();
            return response;
        }
        [Authorize]
        [HttpGet("{id}")]
        public BaseResponse<ProductDto> GetById(int id)
        {
            var response = productService.GetById(id);
            return response;
        }
        [Authorize]
        [HttpDelete("{id}")]
        public BaseResponse<ProductDto> Delete(int id)
        {
            var response = productService.Remove(id);
            return response;
        }
        [Authorize]
        [HttpPost]
        public BaseResponse<ProductDto> Create([FromBody] ProductDto dto)
        {
            var response = productService.Insert(dto);
            return response;
        }
        [Authorize]
        [HttpPut("{id}")]
        public BaseResponse<ProductDto> Update(int id, [FromBody] ProductDto dto)
        {
            var response = productService.Update(id, dto);
            return response;
        }
    }
}
