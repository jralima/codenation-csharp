using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("candidate")]
    public class Candidate
    {
        public int Id { get; set; }
        public int UserId { get; set; }

        public int AccelerationId { get; set; }

        public int CompanyId { get; set; }

        public int Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Acceleration Acceleration { get; set; }

        public virtual Company Company { get; set; }

        public virtual User User { get; set; }
    }
}