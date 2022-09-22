using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Dto;
using PycApi.Service;
using PycApi.Data;
using PycApi.Base;

namespace PycApi.Controller
{
    //Added methods by inheriting from base service
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class BrandController : BaseController<BrandDto, Brand>
    {
        private readonly IBrandService brandService;
        private readonly IMapper mapper;


        public BrandController(IBrandService brandService, IMapper mapper) : base(brandService, mapper)
        {
            this.mapper = mapper;
            this.brandService = brandService;
        }

    }
}
