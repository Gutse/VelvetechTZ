using System.Threading.Tasks;
using FluentAssertions;
using Moq;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Core.Group;
using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Repository;
using Xunit;

namespace VelvetechTZ.Core.Test
{
    public class GroupServiceTest: BaseUnitTest
    {

        private GroupService sut;
        private readonly Mock<IRepository<GroupModel>> groupRepository = new Mock<IRepository<GroupModel>>();

        public GroupServiceTest()
        {
            sut = new GroupService(groupRepository.Object, mapper);
        }

        [Fact]
        public async Task Should_pass_params_Correctly()
        {
            var contract = new GroupContract
            {
                Name = "Test Group"
            };

            groupRepository.Setup(r => r.Insert(It.IsAny<GroupModel>())).ReturnsAsync((GroupModel model) =>
            {
                model.Name.Should().Be(contract.Name);
                return 1;
            });

            var result = await sut.Create(contract);
            groupRepository.VerifyAll();
        }
    }
}
