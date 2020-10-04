using System;
using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using FluentValidation;
using Moq;
using VelvetechTZ.Contract.Domain.Student;
using VelvetechTZ.Contract.Enums;
using VelvetechTZ.Core.Student;
using VelvetechTZ.DAL.Models.Student;
using VelvetechTZ.DAL.Repository;
using Xunit;

namespace VelvetechTZ.Core.Test
{
    public class StudentServiceTest : BaseUnitTest
    {

        private StudentService sut;
        private readonly StudentContractValidator studentContractValidator = container.Resolve<StudentContractValidator>();
        private readonly Mock<IRepository<StudentModel>> studentRepository = new Mock<IRepository<StudentModel>>();

        public StudentServiceTest()
        {
            sut = new StudentService(studentRepository.Object, mapper, studentContractValidator);
        }

        [Fact]
        public async Task Should_pass_params_Correctly()
        {
            var contract = new StudentContract()
            {
                Gender = Gender.Male,
                Family = "Krasavin",
                Name = "Daniil",
                SureName = "Jurevich",
                StudentId = "candidate"
            };

            studentRepository.Setup(r => r.Insert(It.IsAny<StudentModel>())).ReturnsAsync((StudentModel model) =>
            {
                model.Name.Should().Be(contract.Name);
                model.Gender.Should().Be((int)contract.Gender);
                model.Family.Should().Be(contract.Family);
                model.SureName.Should().Be(contract.SureName);
                model.StudentId.Should().Be(contract.StudentId);
                return 1;
            });

            var result = await sut.Create(contract);
            studentRepository.VerifyAll();
        }

        [Fact]
        public async Task Should_throw_on_no_name()
        {
            var contract = new StudentContract()
            {
                Gender = Gender.Male,
                Family = "Krasavin",
                Name = "",
                SureName = "Jurevich",
                StudentId = "candidate"
            };

            var act = new Func<Task>(async () => await sut.Create(contract));
            await act.Should().ThrowAsync<ValidationException>();
        }

        [Fact]
        public async Task Should_throw_on_long_name()
        {
            var contract = new StudentContract()
            {
                Gender = Gender.Male,
                Family = "Krasavin",
                Name = "11111111111111111111111111111111111111111111111111111",
                SureName = "Jurevich",
                StudentId = "candidate"
            };

            var act = new Func<Task>(async () => await sut.Create(contract));
            await act.Should().ThrowAsync<ValidationException>();
        }

        // TODO more test
    }
}