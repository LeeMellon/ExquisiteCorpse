using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;

namespace ExquisiteCorpse1.ViewModels
{
    public class CorpseDisplayAllViewModel
    {
        public Corpse Corpse { get; set; }
        public List<ApplicationUser> Players { get; set; }

        //public CorpseDisplayAllViewModel() => Players = Corpse.Players.ToList();
    }
}
