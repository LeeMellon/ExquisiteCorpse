using ExquisiteCorpse1.Models;
using ExquisiteCorpse1.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ExquisiteCorpse1.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagementController(ApplicationDbContext db,
          UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Index()
        {

            var vm = new UserManagementIndexViewModel
            {
                Users = _db.ApplicationUsers.OrderBy(u => u.ProfileName).Include(u => u.Roles).ToList()
            };

            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> AddRole(string id)
        {
            var user = await GetUserById(id);
            var vm = new UserManagementAddRoleViewModel
            {
                Roles = GetAllRoles(),
                UserId = id,
                ProfileName = user.ProfileName
            };
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> AddRole(UserManagementAddRoleViewModel rvm)
        {
            var user = await GetUserById(rvm.UserId);
            if (ModelState.IsValid)
            {
                var result = await _userManager.AddToRoleAsync(user, rvm.NewRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(error.Code, error.Description);
                }
            }
            rvm.ProfileName = user.ProfileName;
            rvm.Roles = GetAllRoles();
            return View(rvm);

        }

        private async Task<ApplicationUser> GetUserById(string id) =>
            await _userManager.FindByIdAsync(id);

        private SelectList GetAllRoles() => new SelectList(_roleManager.Roles.OrderBy(r => r.Name));

    }
}