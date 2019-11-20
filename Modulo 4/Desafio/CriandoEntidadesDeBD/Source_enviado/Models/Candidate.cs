using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Codenation.Challenge.Models
{

    [Table("candidate")]
    public class Candidate
    {
        [Key]
        //[Column("id"), Required]
        //public int Id { get; set; }//primary key

        [Column("status"), Required]
        public int Status { get; set; }
        [Column("created_at"), Required]
        public DateTime Create_at { get; set; }


        [Column("user_id"), Required]
        public int UserId { get; set; }
        [ForeignKey("UserId"), Required]
        public User User { get; set; }// referencia 


        [Column("acceleration_id"), Required]
        public int AccelerationId { get; set; }
        [ForeignKey("AccelerationId"), Required]
        public Acceleration Acceleration { get; set; }// referencia 


        [Column ("company_id"), Required]
        public int CompanyId { get; set; }
        [ForeignKey("CompanyId"), Required]
        public Company Company { get; set; }// referencia 


    }
}
