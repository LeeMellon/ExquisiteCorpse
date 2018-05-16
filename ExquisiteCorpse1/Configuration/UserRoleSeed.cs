using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.Configuration
{
    public class UserRoleSeed
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRoleSeed(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }   

        public async void Seed()
        {
 
            if((await _roleManager.FindByNameAsync("Player")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Player" });
            }
            if ((await _roleManager.FindByNameAsync("Admin")) == null)
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            
        }

        
    }
}
