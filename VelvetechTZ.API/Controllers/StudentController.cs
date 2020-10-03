using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Contract.Domain.Student;
using VelvetechTZ.Core.Student;

namespace VelvetechTZ.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[AllowAnonymous] //TODO just for testing, dont forget remove 
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // вообще стоит создать на все методы контроллеров классы вида GetFilteredRequest, UpdateStudentRequest +  классы Response итп. но в тестовом задании не буду тратить время
        [HttpPost]
        public async Task<IActionResult> GetFiltered(StudentContract filter)
        {
            var students = await studentService.GetFiltered(filter);
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentContract student)
        {
            var id = await studentService.Create(student);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] StudentContract student)
        {
            await studentService.Update(student);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] StudentContract student)
        {
            await studentService.Delete(student);
            return Ok();
        }
    }
}
