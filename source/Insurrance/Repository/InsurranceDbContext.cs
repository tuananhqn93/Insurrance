using Insurrance.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Insurrance.Repository
{
    public class InsurranceDbContext : DbContext
    {
        public InsurranceDbContext()
            : base("name=InsurranceDbContext")
        {
        }

        public virtual DbSet<Superuser> Superusers { get; set; }
        public virtual DbSet<Callcenter> Callcenters { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Superuser>()
                .Property(s => s.Username)
                .IsUnicode(false);

            modelBuilder.Entity<Callcenter>()
                .Property(s => s.Username)
                .IsUnicode(false);
        }
    }
}