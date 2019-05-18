using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GT.Models
{
    public class UserDeed : BaseEntity
    {
        [Key]
        public Guid UserDeedId { get; set; }
        //[Required]
        public Guid UserId { get; set; }
        public User User { get; set; }
        //[Required]
        public Guid DeedId { get; set; }
        public Deed Deed { get; set; }
    }
}
