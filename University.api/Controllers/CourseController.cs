using AutoWrapper.Wrappers;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using University.api.Filters;
using University.Core.DTOs;
using University.Core.Forms;
using University.Core.Services;

namespace University.api.Controllers
{
    [Route("api/[controller]")]
    [TypeFilter(typeof(ApiExceptionFilter))]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CourseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ApiResponse GetById(int id)
        {
            var dto = _courseService.GetById(id);
            return new ApiResponse(dto);
        }

        [HttpGet()]
        [ProducesResponseType(typeof(List<CourseDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse GetAll()
        {
            var dto = _courseService.GetAll();
            return new ApiResponse(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ApiResponse Create([FromBody] CreateCourseForm form)
        {
            _courseService.Create(form);
            return new ApiResponse(HttpStatusCode.Created);
        }

        [HttpPut("{id}")]
        public ApiResponse Update(int id, [FromBody] UpdateCourseForm form)
        {
            _courseService.Update(id, form);
            return new ApiResponse(HttpStatusCode.OK);
        }

        [HttpDelete("{id}")]
        public ApiResponse Delete(int id)
        {
            _courseService.Delete(id);
            return new ApiResponse(HttpStatusCode.OK);
        }
    }
}