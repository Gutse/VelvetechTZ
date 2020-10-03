using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Core.Group;

namespace VelvetechTZ.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[AllowAnonymous] //TODO just for testing, dont forget remove 
    public class GroupController : ControllerBase
    {
        private readonly IGroupService groupService;

        public GroupController(IGroupService groupService)
        {
            this.groupService = groupService;
        }

        [HttpPost]
        public async Task<IActionResult> GetFiltered(GroupContract filter)
        {
            var groups = await groupService.GetFiltered(filter);
            return Ok(groups);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] GroupContract group)
        {
            var id = await groupService.Create(group);
            return Ok(id);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] GroupContract group)
        {
            await groupService.Update(group);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] GroupContract group)
        {
            await groupService.Delete(group);
            return Ok();
        }
    }
}