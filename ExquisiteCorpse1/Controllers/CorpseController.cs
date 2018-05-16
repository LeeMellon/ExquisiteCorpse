using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;
using ExquisiteCorpse1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExquisiteCorpse1.Controllers
{
    public class CorpseController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CorpseController(ApplicationDbContext db,
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

        public async Task<IActionResult> CreateAsync()
        {
            var thisUser = await _userManager.GetUserAsync(HttpContext.User);
            var users = _db.ApplicationUsers.ToList();
            foreach(ApplicationUser user in users)
            {
                thisUser.AddFriend(user);
            }
            ViewBag.thisUser = thisUser;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Corpse corpse)
        {
            
            return View();
        }
    }
}
