using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.Models
{
    [Table("UsersSections")]
    public class UserSection
    {
        [Key]
        public int UserSectionId { get; set; }

        public string UserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        public int SectionId { get; set; }
        public Section Section { get; set; }
    }
}
