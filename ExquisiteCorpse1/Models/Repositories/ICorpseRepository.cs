using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.Models.Repositories
{
    interface ICorpseRepository
    {
        IQueryable<Section> Sections { get; }
        Corpse Save(Corpse corpse);
        Corpse Edit(Corpse corpse);
        void Remove(Corpse corpse);
        void ClearAll();
    }
}
