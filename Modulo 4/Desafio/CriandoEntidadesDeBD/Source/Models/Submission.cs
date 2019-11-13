using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("submission")]
    public class Submission
    {
        public int Id { get; set; }
        public int ChallengeId { get; set; }

        public int UserId { get; set; }

        public float Score { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Challenge Challenge { get; set; }

        public virtual User User { get; set; }
    }
}