using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Wan.Release.Infrastructure.Test
{
   [Table("Student")]
   public class Student :Entity.Entity
    {

       public string Name { get; set; }

       public string Age { get; set; }
    }
}
