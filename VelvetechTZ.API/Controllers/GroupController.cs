using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Contract.Common;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Core.Group;

namespace VelvetechTZ.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [AllowAnonymous] //TODO remove on release
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;
        private readonly IMapper mapper;

        public GroupController(IGroupService groupService, IMapper mapper)
        {
            this.groupService = groupService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Get(BaseGetByIdRequest request)
        {
            var group = await groupService.Get(request.Id);
            return Ok(new BaseContractResponse<GroupContract> { Result = group });
        }

        [HttpPost]
        public async Task<IActionResult> GetFiltered(BaseFilterRequest<GroupContract> filter)
        {
            var groups = await groupService.GetFiltered(filter.Filter);
            return Ok(new BaseCollectionResponse<GroupContract> { Result = groups });
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupCreateRequest request)
        {
            var contract = mapper.Map<GroupContract>(request);
            var id = await groupService.Create(contract);
            return Ok(new BaseIdResponse { Id = id });
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] GroupUpdateRequest request)
        {
            var contract = mapper.Map<GroupContract>(request);
            await groupService.Update(contract);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] BaseDeleteRequest request)
        {
            await groupService.Delete(request.Id);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent([FromBody] GroupAddStudentRequest request)
        {
            await groupService.AddStudent(request.GroupId, request.StudentId);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> RemoveStudent([FromBody] GroupRemoveStudentRequest request)
        {
            await groupService.RemoveStudent(request.GroupId, request.StudentId);
            return Ok();
        }
    }
}