using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("acceleration")]
    public class Acceleration
    {
        [Key]
        [Column("id"), Required]
        public int Id { get; set; }//primary key

        [Column("name"), Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Column("slug"), Required]
        [MaxLength(50)]
        public string Slug { get; set; }

        [Column("created_at"), Required]
        public DateTime Create_at { get; set; }


        [Column("challenge_id"), Required]
        public int ChallengeId { get; set; }//foreign key
        [ForeignKey("ChallengeId"), Required]
        public Challenge Challenge { get; set; }// referencia 


        public ICollection<Candidate> Candidates{ get; set; }

    }
}
