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
    public class CategoryController : BaseController<CategoryDto, Category>
    {
        private readonly ICategoryService categoryService;
        private readonly IMapper mapper;


        public CategoryController(ICategoryService categoryService, IMapper mapper) : base(categoryService, mapper)
        {
            this.mapper = mapper;
            this.categoryService = categoryService;
        }





    }
}
