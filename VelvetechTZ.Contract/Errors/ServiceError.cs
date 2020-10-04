namespace VelvetechTZ.Contract.Errors
{
    public class ServiceError
    {
        public int Code { get; set; }
        public string? Description { get; set; }
        public ValidationError? Meta { get; set; }
    }
}