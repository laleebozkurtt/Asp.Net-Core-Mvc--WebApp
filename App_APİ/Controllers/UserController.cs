using Infrastructure.Context;
using Infrastructure.Interfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace App_APİ.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private IStudentService _studentService;
        public UserController(AppDbContext context)
        {
            _studentService = new StudentService(context);
        }

        [HttpGet]
        public IActionResult Get()
        {
          
            var result = _studentService.GetStudentList();

            if (result.Any())
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Student not exist");
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            //return _studentService.GetStudentById(id);

            var result = _studentService.GetStudentById(id);

            if (result!=null )
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Student not exist");
            }
        }

        [HttpPost("create")]
        public IActionResult CreateStudent([FromBody] Student student)
        {
            var result = _studentService.CreateStudent(student);

            if (result.Id > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Student not created");
            }
        }

        [HttpPost("UpdateStudent")]
        //[Authorize(AuthenticationSchemes = "Bearer")]
        [Authorize]
        //[AllowAnonymous] 
        public IActionResult UpdateStudent([FromBody] Student student)
        {
            var result = _studentService.UpdateStudent(student);

            if ( result !=null && result.Id > 0)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Student not updated");
            }
        }

        [HttpPost("delete")]
        [Authorize]
        public IActionResult DeleteStudent(int id)
        {
            var result = _studentService.DeleteStudent(id);

            if (result > 0 && result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest("Student not updated");
            }
        }

        [HttpGet("secret")]
        [Authorize(Roles = "Admin")]
        public IActionResult SecretData()
        {
            return Ok("Bu veri sadece token olanlara açık");
        }


    }
}

