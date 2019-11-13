using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{
    [Table("user")]
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; }
        
        public string NickName { get; set; }

        public string Email { get; set; }
        
        public string Password { get; set; }

        public DateTime CreatedAt { get; set; }

        public List<Candidate> Candidates { get; set; }
        public List<Submission> Submissions { get; set; }
    }
}