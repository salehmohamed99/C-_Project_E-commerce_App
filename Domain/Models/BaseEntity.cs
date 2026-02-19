using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class BaseEntity<TKey>
    {
        public TKey ID { get; set; }

        public string CreatedBy { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime? UpdatedAt { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
