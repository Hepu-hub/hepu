using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using MySql.Data.EntityFramework;
using WindowsFormsApp2;

namespace WindowsFormsApp2
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class OrderDbContext : DbContext
    {
        public OrderDbContext() : base("name=OrderDbContext")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<OrderDbContext>());
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Details)
                .WithRequired(d => d.Order)
                .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}