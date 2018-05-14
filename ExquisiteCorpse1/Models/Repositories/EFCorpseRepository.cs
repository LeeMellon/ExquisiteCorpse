using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExquisiteCorpse1.Models;
using Microsoft.EntityFrameworkCore;

namespace ExquisiteCorpse1.Models.Repositories
{
    public class EFCorpseRepository : ICorpseRepository
    {
        ApplicationDbContext db;
        public EFCorpseRepository()
        {
            db = new ApplicationDbContext();
        }
        public EFCorpseRepository(ApplicationDbContext thisDb)
        {
            db = thisDb;
        }

        public IQueryable<Section> Sections { get { return db.Sections; } }

        public Corpse Edit(Corpse corpse)
        {
            db.Entry(corpse).State = EntityState.Modified;
            db.SaveChanges();
            return corpse;
        }

        public Corpse Save(Corpse corpse)
        {
            db.Corpses.Add(corpse);
            db.SaveChanges();
            return corpse;
        }

        public void Remove(Corpse corpse)
        {
            db.Corpses.Remove(corpse);
            db.SaveChanges();
        }

        public void ClearAll()
        {
            db.Corpses.RemoveRange(db.Corpses);
            db.SaveChanges();
        }
    }
}
