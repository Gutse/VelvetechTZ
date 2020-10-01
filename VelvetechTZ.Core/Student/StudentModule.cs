using Autofac;

namespace VelvetechTZ.Core.Student
{
    public class StudentModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<StudentService>().As<IStudentService>();
        }
    }
}