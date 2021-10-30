using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace RestaurantManagementApp.Model
{
    public partial class Context : DbContext
    {
        public Context()
            : base("name=Context")
        {
        }

        public virtual DbSet<Aliment> Aliments { get; set; }
        public virtual DbSet<AlimentSize> AlimentSizes { get; set; }
        public virtual DbSet<AlimentType> AlimentTypes { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }
        public virtual DbSet<Notification> Notifications { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Table> Tables { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Top5Drink> Top5Drink { get; set; }
        public virtual DbSet<Top5Food> Top5Food { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aliment>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Aliment>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Aliment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AlimentSize>()
                .Property(e => e.SizeName)
                .IsUnicode(false);

            modelBuilder.Entity<AlimentSize>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.AlimentSize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Invoice>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Invoice>()
                .HasMany(e => e.InvoiceDetails)
                .WithRequired(e => e.Invoice)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .Property(e => e.IDCard)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);
        }
    }
}
