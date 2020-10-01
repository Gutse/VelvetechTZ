using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Core.Student;

namespace VelvetechTZ.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // вообще стоит создать на все методы контроллеров классы вида GetFilteredRequest, UpdateStudentRequest +  классы Response итп. но в тестовом задании не буду тратить время
        [HttpPost]
        public async Task<IActionResult> GetFiltered(StudentDto filter)
        {
            var students = await studentService.GetFiltered(filter);
            return Ok(students);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentDto student)
        {
            var id = await studentService.Create(student);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] StudentDto student)
        {
            await studentService.Update(student);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] StudentDto student)
        {
            await studentService.Delete(student);
            return Ok();
        }
    }
}
