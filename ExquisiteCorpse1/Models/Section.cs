using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteCorpse1.Models
{
    [Table("Sections")]
    public class Section
    {
        [Key]
        public int SectionId { get; set; }
        [ForeignKey("CorpseId")]
        public int CorpseId { get; set; }
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public string SectionText { get; set; }
        public string Stub { get; set; }
       
        
        public Section() { }


    }

}
