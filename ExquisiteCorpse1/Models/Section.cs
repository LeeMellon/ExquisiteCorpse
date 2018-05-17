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
        public virtual Corpse Corpse { get; set; }
        [ForeignKey("UserId")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
        public string SectionText { get; set; }
        public string Stub { get; set; }
       
        
        public Section() { }

        public string GetProfileName()
        {
            return User.ProfileName;
        }

        public string GetPreviousStub()
        {
            var sectionCount = Corpse.Sections.Count;
            if(sectionCount > 0)
            {
                return Corpse.Sections[sectionCount - 1].Stub;
            }
            else
            {
                return "Begin You Story Now";
            }
        }

    }

}
