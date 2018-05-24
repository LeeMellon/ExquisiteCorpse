using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.Models
{
    [Table("UsersCorpses")]
    public class UserCorpse
    {
        [Key]
        public int UserCorpseId { get; set; }
        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int CorpseId { get; set; }
        public Corpse Corpse { get; set; }

        public string Status { get; set; }

        //Need Medthod to Generate New UCs Needs to be in COrpse Model?
    }
}
