using System;
using System.ComponentModel.DataAnnotations;

namespace GT.Models
{
    public class User : BaseEntity
    {
        [Key]
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

    }
}
