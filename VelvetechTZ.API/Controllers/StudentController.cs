using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Contract.Common;
using VelvetechTZ.Contract.Domain.Student;
using VelvetechTZ.Core.Student;

namespace VelvetechTZ.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;
        private readonly IMapper mapper;

        public StudentController(IStudentService studentService, IMapper mapper)
        {
            this.studentService = studentService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> GetFiltered(BaseFilterRequest<StudentContract> request)
        {
            var students = await studentService.GetFiltered(request.Filter);
            return Ok(new BaseCollectionResponse<StudentContract> { Result = students });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] StudentCreateRequest request)
        {
            var contract = mapper.Map<StudentContract>(request);
            var id = await studentService.Create(contract);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] StudentUpdateRequest request)
        {
            var contract = mapper.Map<StudentContract>(request);
            await studentService.Update(contract);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] BaseDeleteRequest request)
        {
            await studentService.Delete(request.Id);
            return Ok();
        }
    }
}
