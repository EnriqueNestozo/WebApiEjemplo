using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCursos.Interfaces;
using WebApiCursos.Model;

namespace WebApiCursos.Controllers
{
    [Route("api/[controller]")]
    [ApiController] //da algunas opciones extra como validacion automática del modelo o inferencia de los parametros cuando se solicitad al cliente
    public class CoursesController : ControllerBase
    {
        private readonly ICoursesProvider coursesProviders;

        public CoursesController(ICoursesProvider coursesProviders)
        {
            this.coursesProviders = coursesProviders;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var result = await coursesProviders.GetAllAsync();
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var result = await coursesProviders.GetAsync(id);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(id);
        }

        [HttpGet("search/{search}")]
        public async Task<IActionResult> SearchAsync(string search)
        {
            var result = await coursesProviders.SearchAsync(search);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound(search);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Course course)
        {
            var result = await coursesProviders.UpdateAsync(course);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Course course)
        {
            if(course == null)
            {
                return BadRequest();
            }
            var result = await coursesProviders.AddAsync(course);
            if (result.isSuccess)
            {
                return Ok(result.Id);
            }
            return NotFound();
        }
    }
}