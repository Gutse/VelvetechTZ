namespace VelvetechTZ.Contract.Common
{
    public class BaseContractResponse<T> where T : class
    {
        public T? Result { get; set; }
    }
}