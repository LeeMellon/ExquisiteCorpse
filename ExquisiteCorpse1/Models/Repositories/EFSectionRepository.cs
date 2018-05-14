using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace ExquisiteCorpse1.Models.Repositories
{
    public class EFSectionRepository : ISectionRepository
    {
        ApplicationDbContext db;
        public EFSectionRepository()
        {
            db = new ApplicationDbContext();
        }

        public EFSectionRepository(ApplicationDbContext thisDb)
        {
            db = thisDb;
        }

        public Section Save(Section section)
        {
            db.Sections.Add(section);
            db.SaveChanges();
            return section;
        }

        public Section Edit(Section section)
        {
            db.Entry(section).State = EntityState.Modified;
            db.SaveChanges();
            return section;
        }

        public void Remove(Section section)
        {
            db.Sections.Remove(section);
            db.SaveChanges();
        }

        public void ClearAll()
        {
            db.Sections.RemoveRange(db.Sections);
            db.SaveChanges();
        }
    }
}
