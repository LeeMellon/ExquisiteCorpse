using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.Models.Repositories
{
    interface ISectionRepository
    {
        Section Save(Section section);
        Section Edit(Section section);
        void Remove(Section section);
        void ClearAll();

    }
}
