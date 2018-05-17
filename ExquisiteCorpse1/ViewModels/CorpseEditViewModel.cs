using ExquisiteCorpse1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.ViewModels
{
    public class CorpseEditViewModel
    {
        public List<string> Stubs { get; set; }
        public Corpse Corpse { get; set; }
        public List<string> ProfileNames { get; set; }
    }
}
