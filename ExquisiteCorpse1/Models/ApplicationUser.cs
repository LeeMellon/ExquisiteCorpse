using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExquisiteCorpse1.Models
{
    [Table("ApplicationUsers")]
    public class ApplicationUser : IdentityUser
    {
       
        public string ProfileName { get; set; }
        public virtual List<Section> Sections { get; set; }
        public virtual List<UserCorpse> UserCorpses { get; set; }
        public virtual List<ApplicationUser> Friends { get; set; }


        public ApplicationUser()
        {
            Friends = new List<ApplicationUser> { };
        }
        public override bool Equals(System.Object otherApplicationUser)
        {
            if (!(otherApplicationUser is ApplicationUser))
            {
                return false;
            }
            else
            {
                ApplicationUser newApplicationUser = (ApplicationUser)otherApplicationUser;
                return this.Id.Equals(newApplicationUser.Id);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
        public void AddFriend(ApplicationUser friend)
        {
            Friends.Add(friend);
        }

    }
}
