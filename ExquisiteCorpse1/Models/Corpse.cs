using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;

namespace ExquisiteCorpse1.Models
{
    [Table("Corpses")]
    public class Corpse
    {
        [Key]
        public int CorpseId { get; set; }
        public string Title { get; set; }
        public List<Section> Sections { get; set; }
        public List<ApplicationUser> Players { get; set; }
        public int Rounds { get; set; }
        public int CurrentRound { get; set; }
        public List<UserCorpse> UserCorpses { get; set; }


        public Corpse() { }

       

       

    }
}
