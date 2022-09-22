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
    public class ColorController : BaseController<ColorDto, Color>
    {
        private readonly IColorService colorService;
        private readonly IMapper mapper;


        public ColorController(IColorService colorService, IMapper mapper) : base(colorService, mapper)
        {
            this.mapper = mapper;
            this.colorService = colorService;
        }





    }
}
