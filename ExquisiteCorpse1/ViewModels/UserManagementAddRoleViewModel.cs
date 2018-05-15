using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.ViewModels
{
    public class UserManagementAddRoleViewModel
    {
        public string UserId { get; set; }
        public string NewRole { get; set; }
        public SelectList Roles { get; set; }
        public string ProfileName { get; set; }
    }
}
