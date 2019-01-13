using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }

        [Index("IX_CreatedDate")]
        public DateTimeOffset CreatedDate { get; set; }

        [StringLength(50)]
        [Index("IX_CreatedBy")]
        public string CreatedBy { get; set; }

        public DateTimeOffset ModifiedDate { get; set; }

        [StringLength(50)]
        public string ModifiedBy { get; set; }
    }
}
