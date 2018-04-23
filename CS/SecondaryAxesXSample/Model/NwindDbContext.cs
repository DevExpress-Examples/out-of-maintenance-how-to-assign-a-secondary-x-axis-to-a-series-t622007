namespace SecondaryAxesXSample {
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class NwindDbContext : DbContext {
        public NwindDbContext()
            : base("name=NwindDbContext") {
        }

        public virtual DbSet<SalesPerson> SalesPersons { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder) {
            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.UnitPrice)
                .HasPrecision(10, 4);

            modelBuilder.Entity<SalesPerson>()
                .Property(e => e.ExtendedPrice)
                .HasPrecision(19, 4);
        }
    }
}
