using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace LW11
{
    public partial class UniversityModel : DbContext
    {
        public UniversityModel()
            : base("name=UniversityModel1")
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .Property(e => e.PhoneNumber)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
