using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PycApi.Service;

namespace PycApi
{

    [ApiController]
    public class BaseController<Dto, Entity> : ControllerBase
    {

        private readonly IBaseService<Dto, Entity> baseService;
        private readonly IMapper mapper;


        public BaseController(IBaseService<Dto, Entity> baseService, IMapper mapper)
        {
            this.baseService = baseService;
            this.mapper = mapper;
        }


        [HttpGet]
        public virtual IActionResult GetAll()
        {
            var result = baseService.GetAll();

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpGet("{id}")]
        public virtual IActionResult GetById(int id)
        {
            var result = baseService.GetById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            return Ok(result);
        }

        [HttpPost]
        public virtual IActionResult Create([FromBody] Dto dto)
        {
         
            var result = baseService.Insert(dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(201, result);
            }

            return BadRequest(result);
        }

        [HttpPut("{id}")]
        public virtual IActionResult Update(int id, [FromBody] Dto dto)
        {
            var result = baseService.Update(id, dto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            if (result.Response is null)
            {
                return NoContent();
            }

            if (result.Success)
            {
                return StatusCode(200, result);
            }

            return BadRequest(result);
        }

        [HttpDelete]
        public virtual IActionResult Delete(int id)
        {
            var result = baseService.Remove(id);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }


    }
}
