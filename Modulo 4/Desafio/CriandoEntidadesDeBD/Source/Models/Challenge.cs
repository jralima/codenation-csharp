using System;
using System.Collections.Generic;

namespace Codenation.Challenge.Models
{
    public class Challenge
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Acceleration> Accelerations { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}