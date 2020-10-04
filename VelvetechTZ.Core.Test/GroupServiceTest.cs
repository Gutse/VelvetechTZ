using System;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using FluentValidation;
using Moq;
using VelvetechTZ.Contract.Domain.Group;
using VelvetechTZ.Core.Group;
using VelvetechTZ.DAL.Models.Group;
using VelvetechTZ.DAL.Models.Student;
using VelvetechTZ.DAL.Repository;
using Xunit;

namespace VelvetechTZ.Core.Test
{
    public class GroupServiceTest : BaseUnitTest
    {

        private GroupService sut;
        private readonly GroupContractValidator groupContractValidator = container.Resolve<GroupContractValidator>();
        private readonly Mock<IRepository<GroupModel>> groupRepository = new Mock<IRepository<GroupModel>>();
        private readonly Mock<IRepository<StudentModel>> studentRepository = new Mock<IRepository<StudentModel>>();

        public GroupServiceTest()
        {
            sut = new GroupService(groupRepository.Object, mapper, groupContractValidator, studentRepository.Object);
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

        [Fact]
        public async Task Should_throw_on_no_name()
        {
            var contract = new GroupContract
            {
                Name = ""
            };

            var act = new Func<Task>(async () => await sut.Create(contract));
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task Should_throw_on_long_name()
        {
            var contract = new GroupContract
            {
                Name = "1234567890123456789012345678901234567890"
            };

            var act = new Func<Task>(async () => await sut.Create(contract));
            await act.Should().ThrowAsync<ValidationException>();
        }
    }
}
