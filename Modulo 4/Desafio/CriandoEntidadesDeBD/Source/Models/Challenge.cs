using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("challenge")]
    public class Challenge
    {
        [Key]
        [Column("id"), Required]
        public int Id { get; set; }

        [Column("name"), Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("slug"), Required]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Column("created_at"), Required]
        public DateTime Create_at { get; set; }
       

        public ICollection<Acceleration> Accelerations { get; set; }
        public ICollection<Submission> Submissions { get; set; }


    }
}
