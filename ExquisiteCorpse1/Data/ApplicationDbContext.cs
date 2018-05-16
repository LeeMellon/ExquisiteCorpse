using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExquisiteCorpse1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=exquisite_corpse;uid=root;pwd=root;");
        }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public virtual DbSet<Corpse> Corpses { get; set; }
        public virtual DbSet<Section> Sections { get; set; }
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public virtual DbSet<UserCorpse> UserCorpses { get; set; }
        public virtual DbSet<UserSection> UserSections { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>(entity => {
                entity.Property(m => m.Email).HasMaxLength(127);
                entity.Property(m => m.NormalizedEmail).HasMaxLength(127);
                entity.Property(m => m.NormalizedUserName).HasMaxLength(127);
                entity.Property(m => m.UserName).HasMaxLength(127);
            });
            builder.Entity<IdentityRole>(entity => {
                entity.Property(m => m.Name).HasMaxLength(127); entity.Property(m => m.NormalizedName).HasMaxLength(127);
            });
            builder.Entity<UserCorpse>()
                .HasKey(p => new { p.UserId, p.CorpseId });
            builder.Entity<UserCorpse>()
                .HasOne(uc => uc.ApplicationUser)
                .WithMany(u => u.UserCorpses)
                .HasForeignKey(uc => uc.UserId);
            builder.Entity<UserCorpse>()
                .HasOne(uc => uc.Corpse)
                .WithMany(c => c.UserCorpses)
                .HasForeignKey(uc => uc.CorpseId);

        }
    }
}
