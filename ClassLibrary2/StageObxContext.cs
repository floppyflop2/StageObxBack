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
    using MySql.Data.Entity;
    using MySql.Data.MySqlClient;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class StageObxContext : DbContext
    {

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Internship> Internship { get; set; }

        public StageObxContext() : base("name=StageObxModel")
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public StageObxContext(string connectionstring) : base(connectionstring)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        public StageObxContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {
            DbConfiguration.SetConfiguration(new MySqlEFConfiguration());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Companies>()
                .HasMany(e => e.Contacts)
                .WithRequired(e => e.Companies)
                .WillCascadeOnDelete(false);
        }


    }



}

