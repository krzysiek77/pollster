using System;

namespace pollster.domain.Entities
{
    public class Audit
    {
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public bool IsExisting { get; set; }
        // public int CreatedById { get; set; }
        // public int UpdatedById { get; set; }
        // public int DeletedById { get; set; }

        // public User Creator { get; set; }
        // public User Modifier { get; set; }
        // public User Eraser { get; set; }
    }
}