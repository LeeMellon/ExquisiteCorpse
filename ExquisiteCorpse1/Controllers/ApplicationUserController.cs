using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;
using ExquisiteCorpse1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            if (viewOption == null)
            {
                throw new ArgumentNullException(nameof(viewOption));
            }


            var thisUser = await _userManager.GetUserAsync(HttpContext.User);
            List<CorpseDisplayAllViewModel> corpseList = new List<CorpseDisplayAllViewModel> { };
            var thisList = _db.UserCorpses.Where(uc => uc.UserId == thisUser.Id).Select(uc => uc.CorpseId).ToList();
            foreach(int id in thisList)
            {
            var testEms = _db.Corpses.Include(c => c.Players).FirstOrDefault(c => c.CorpseId == id);

            }
            //        if (viewOption == "All")
            //        {
            //            foreach (Corpse c in thisList)
            //            {
            //                corpseList.Add(new CorpseDisplayAllViewModel { Corpse = c });
            //            }

            return View(corpseList);

            //        }
            //        else
            //        {
            //            List<Corpse> thisModel = new List<Corpse> { };
            //            var testr = viewOption;
            //            var listetst = thisList;
            //            foreach (Corpse c in thisList)
            //            {
            //                var test = viewOption;

            //                if (viewOption == "Turn")
            //                {
            //                    if (c.GetCurrentPlayerId() == thisUser.Id)
            //                    {
            //                        thisModel.Add(c);
            //                    }

            //                }
            //                else if (viewOption == "Awaiting")
            //                {
            //                    if (c.Status == "Awaiting")
            //                    {
            //                        thisModel.Add(c);
            //                    }

            //                }
            //                else if (viewOption == "Waiting")
            //                {
            //                    if ((c.Status == "Active") && (c.GetCurrentPlayerId() != thisUser.Id))
            //                    {
            //                        thisModel.Add(c);
            //                    }

            //                }
            //                else if (viewOption == "Complete")
            //                {
            //                    if (c.Status == "Complete")
            //                    {
            //                        thisModel.Add(c);
            //                    }

            //                }
            //            }

            //            return View(thisModel);

            //        }
        }
    }
    }
