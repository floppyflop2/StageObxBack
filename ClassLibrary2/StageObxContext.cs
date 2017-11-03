namespace DBDomain
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Common;
    using System.Data.Entity.Core.Objects;
    using DBDomain;
    using System.Reflection;

    public partial class StageObxContext : DbContext
    {
        public StageObxContext()
            : base("name=StageObxModel")
        {
        }

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Internship> Internship { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companies>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.Companies)
                .WillCascadeOnDelete(false);
        }

    }

}
