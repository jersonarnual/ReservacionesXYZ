using System;

namespace XYZ.Domain
{
    public class BaseEntity
    {
        public DateTime CreateTime { get; set; }
        public DateTime UpdateTime { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
    }
}
