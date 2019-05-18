using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;
using System.Text;

namespace GT.Models
{
    public class Deed : BaseEntity
    {
        [Key]
        public Guid DeedId { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DescriptionPublic { get; set; }
        public string DescriptionPrivate { get; set; }
        [Required]
        public int State { get; set; }
        public int MinCountUsers { get; set; }
        public int MaxCountUsers { get; set; }
        public int CurrentCountUsers { get; set; }

        public Byte[] GeoBytes { get; set; }

        //[Required]
        //[ForeignKey("Id")]
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
