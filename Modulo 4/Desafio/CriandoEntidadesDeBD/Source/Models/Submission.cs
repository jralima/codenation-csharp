using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        [Key]
        [Column("id"),Required]
        public int Id { get; set; }

        [Column("score"), Required]
        public decimal Score { get; set; }

        [Column("created_at"), Required]
        public DateTime Create_at { get; set; }


        [Column("user_id"), Required]
        public int UserId { get; set; }//Foreing key
        [ForeignKey("UserId"), Required]
        public User User { get; set; }//referencia


        [Column("challenge_id"), Required]
        public int ChallengeId { get; set; }//Foreing key
        [ForeignKey("ChallengeId"),Required]
        public Challenge Challenge { get; set; }//referencia


    }
}
