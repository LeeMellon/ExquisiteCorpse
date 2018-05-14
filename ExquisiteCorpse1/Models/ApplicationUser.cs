using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;

namespace ExquisiteCorpse1.Models
{
    [Table("Users")]
    public class ApplicationUser : IdentityUser
    {
        [Key]
        public string UserId { get; set; }
        public string ProfileName { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
        public virtual List<Section> Sections { get; set; }
        public virtual List<UserCorpse> UserCorpses { get; set; }

        public override bool Equals(System.Object otherApplicationUser)
        {
            if (!(otherApplicationUser is ApplicationUser))
            {
                return false;
            }
            else
            {
                ApplicationUser newApplicationUser = (ApplicationUser)otherApplicationUser;
                return this.UserId.Equals(newApplicationUser.UserId);
            }
        }

        public override int GetHashCode()
        {
            return this.UserId.GetHashCode();
        }
    }
}
