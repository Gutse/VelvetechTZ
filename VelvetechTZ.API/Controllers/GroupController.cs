using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Core.Group;

namespace VelvetechTZ.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> GetFiltered(GroupDto filter)
        {
            var groups = await groupService.GetFiltered(filter);
            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupDto group)
        {
            var id = await groupService.Create(group);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] GroupDto group)
        {
            await groupService.Update(group);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] GroupDto group)
        {
            await groupService.Delete(group);
            return Ok();
        }
    }
}