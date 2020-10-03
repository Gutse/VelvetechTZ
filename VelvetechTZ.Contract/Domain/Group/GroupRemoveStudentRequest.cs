namespace VelvetechTZ.Contract.Domain.Group
{
    public class GroupRemoveStudentRequest
    {
        public long GroupId { get; set; }
        public long StudentId { get; set; }
    }
}