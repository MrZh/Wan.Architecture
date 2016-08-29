using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wan.Infrastructure.Test
{
   [Table("Student")]
   public class Student
    {
       [Key]
       public string Id { get; set; }

       public string Name { get; set; }

       public string Age { get; set; }
    }
}
