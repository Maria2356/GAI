using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace GAI
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Avto> Avto { get; set; }
        public virtual DbSet<Drivers> Drivers { get; set; }
        public virtual DbSet<Prava> Prava { get; set; }
        public virtual DbSet<Regi> Regi { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drivers>()
                .HasMany(e => e.Avto)
                .WithRequired(e => e.Drivers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Drivers>()
                .HasMany(e => e.Prava)
                .WithRequired(e => e.Drivers)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Prava>()
                .Property(e => e.licence_number)
                .IsFixedLength();
        }
    }
}
