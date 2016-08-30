using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Wan.Release.Infrastructure.Attribute;

namespace Wan.Release.Infrastructure.Test
{
    [Table("Student")]
    public class Student : Entity.Entity
    {

        public string Name { get; set; }

        [RelId]
        public string Age { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
