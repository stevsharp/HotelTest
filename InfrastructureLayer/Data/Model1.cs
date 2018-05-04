namespace InfrastructureLayer.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HotelDBContext : DbContext 
    {
        public HotelDBContext()
            : base("name=HotelContext")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Hotel>()
                .HasMany(e => e.Customers)
                .WithRequired(e => e.Hotel)
                .WillCascadeOnDelete(false);
        }


    }

    
}
