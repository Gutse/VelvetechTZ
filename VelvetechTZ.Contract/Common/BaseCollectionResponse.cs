using System.Collections.Generic;

namespace VelvetechTZ.Contract.Common
{
    public class BaseCollectionResponse<T> where T: class
    {
        public List<T>? Result { get; set; }
    }
}
