using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wan.Infrastructure.Entity
{
    public class Entity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

    }
}
