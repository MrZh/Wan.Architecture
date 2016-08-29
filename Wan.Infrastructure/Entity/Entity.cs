using System.ComponentModel.DataAnnotations;

namespace Wan.Infrastructure.Entity
{
    public class Entity
    {
        [Key]
        [StringLength(50)]
        public string Id { get; set; }

    }
}
