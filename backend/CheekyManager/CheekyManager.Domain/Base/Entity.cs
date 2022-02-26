using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheekyManager.Domain.Base
{
    public class Entity
    {
        public long Id { get; set; }
        public Guid Uuid { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }

        public bool IsDeleted => DeletedAt > DateTime.MinValue;

        public void Update()
        {
            UpdatedAt = DateTime.UtcNow;
        }

        public void Create()
        {
            CreatedAt = DateTime.UtcNow;
        }
    }
}
