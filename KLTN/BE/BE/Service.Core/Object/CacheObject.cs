using System;

namespace Service.Core.Object
{
    public class CacheObject<T>
    {
        public DateTime AbsoluteTimeOut { get; set; }
        public T Value { get; set; }
    }
}
