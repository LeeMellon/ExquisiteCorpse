﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExquisiteCorpse1.Controllers
{
    public class ApplicationUserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public ApplicationUserController(ApplicationDbContext db,
         UserManager<ApplicationUser> userManager,
           RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayAllView(string viewOption)
        {
            var thisUser = await _userManager.GetUserAsync(HttpContext.User);
            var thisList = _db.Corpses.Select(c => c.Players.Where(p => p.Id == thisUser.Id)).ToList();
            if (viewOption == "All")
            {

                return RedirectToAction("ApplicationUser", "DisplayAllView", thisList);

            }
            else
            {
                List<Corpse> thisModel = new List<Corpse> { };
                foreach (Corpse c in thisList)
                {
                    if (viewOption == "Turn")
                    {
                        if (c.GetCurrentPlayerId() == thisUser.Id)
                        {
                            thisModel.Add(c);
                        }

                    }
                    else if (viewOption == "Awaiting")
                    {
                        if (c.Status == "Awaiting")
                        {
                            thisModel.Add(c);
                        }

                    }
                    else if (viewOption == "Waiting")
                    {
                        if ((c.Status == "Active") && (c.GetCurrentPlayerId() != thisUser.Id))
                        {
                            thisModel.Add(c);
                        }

                    }
                    else if (viewOption == "Complete")
                    {
                        if (c.Status == "Complete")
                        {
                            thisModel.Add(c);
                        }

                    }
                }

                return RedirectToAction("DisplayAllView", thisModel);

            }
        }
    }
}