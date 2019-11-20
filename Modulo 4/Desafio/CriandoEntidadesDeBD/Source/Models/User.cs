using System;
using System.Collections.Generic;

namespace Codenation.Challenge.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        
        public string NickName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public ICollection<Candidate> Candidates { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}