using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRental.Models;

public partial class CarRentalContext : DbContext
{

    public DbSet<Admin> Admins { get; set; }
    public DbSet<Car> Cars { get; set; }
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Reservation> Reservations { get; set; }

    public CarRentalContext()
    {
    }

    public CarRentalContext(DbContextOptions<CarRentalContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-F5G09V2; Database=CarRental; Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Car -> Reservation (One-to-Many)
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Car)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CarId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a Car deletes its Reservations

        // Configure Customer -> Reservation (One-to-Many)
        modelBuilder.Entity<Reservation>()
            .HasOne(r => r.Customer)
            .WithMany(c => c.Reservations)
            .HasForeignKey(r => r.CustomerId)
            .OnDelete(DeleteBehavior.Cascade); // Deleting a Customer deletes their Reservations

        // Configure Admin entity if additional relations are needed (currently independent)
        modelBuilder.Entity<Admin>()
            .Property(a => a.Name)
            .IsRequired()
            .HasMaxLength(100);

        modelBuilder.Entity<Reservation>()
            .Property(r => r.TotalPrice)
            .HasColumnType("decimal(18,2)");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
