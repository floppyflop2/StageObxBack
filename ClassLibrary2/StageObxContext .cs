namespace DBDomain
{
    using System.Data.Entity;
    using System.Data.Common;
    using MySql.Data.Entity;

    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class StageObxContext : DbContext
    {

        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Contacts> Contacts { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Internship> Internship { get; set; }

        public StageObxContext() : base("name=StageObxModel")
        {
        }

        public StageObxContext(string connectionstring) : base(connectionstring)
        {
        }
        public StageObxContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {

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
