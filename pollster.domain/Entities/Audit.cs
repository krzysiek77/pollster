using System;

namespace pollster.domain.Entities
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }
        public bool IsExisting { get; set; }
    }
}