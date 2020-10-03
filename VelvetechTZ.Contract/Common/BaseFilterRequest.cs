namespace VelvetechTZ.Contract.Common
{
    public class BaseFilterRequest<T> where T: class
    {
        public T? Filter { get; set; }
    }
}
