using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace EconSense.Model;

public partial class EconomContext : DbContext
{
    public EconomContext()
    {
    }

    public EconomContext(DbContextOptions<EconomContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargoes { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<Road> Roads { get; set; }

    public virtual DbSet<Route> Routes { get; set; }

    public virtual DbSet<RouteSection> RouteSections { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<TransportExpense> TransportExpenses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Waybill> Waybills { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;port=3307;user=root;database=Econom", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.HasKey(e => e.CargoId).HasName("PRIMARY");

            entity.Property(e => e.CargoId).HasColumnName("Cargo_ID");
            entity.Property(e => e.CargoName)
                .HasMaxLength(255)
                .HasColumnName("Cargo_Name");
            entity.Property(e => e.Volume).HasPrecision(10, 2);
            entity.Property(e => e.Weight).HasPrecision(10, 2);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.HasKey(e => e.DriverId).HasName("PRIMARY");

            entity.Property(e => e.DriverId).HasColumnName("Driver_ID");
            entity.Property(e => e.DrivingLicenseExpiryDate).HasColumnName("Driving_License_Expiry_Date");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.PassportSeriesAndNumber)
                .HasMaxLength(255)
                .HasColumnName("Passport_Series_and_Number");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
        });

        modelBuilder.Entity<Road>(entity =>
        {
            entity.HasKey(e => e.RoadId).HasName("PRIMARY");

            entity.Property(e => e.RoadId).HasColumnName("Road_ID");
            entity.Property(e => e.ArrivalPoint)
                .HasMaxLength(255)
                .HasColumnName("Arrival_Point");
            entity.Property(e => e.RoadLength)
                .HasPrecision(10, 2)
                .HasColumnName("Road_Length");
            entity.Property(e => e.RoadName)
                .HasMaxLength(255)
                .HasColumnName("Road_Name");
        });

        modelBuilder.Entity<Route>(entity =>
        {
            entity.HasKey(e => e.RouteId).HasName("PRIMARY");

            entity.Property(e => e.RouteId).HasColumnName("Route_ID");
            entity.Property(e => e.EndingPoint)
                .HasMaxLength(255)
                .HasColumnName("Ending_Point");
            entity.Property(e => e.RouteLength)
                .HasPrecision(10, 2)
                .HasColumnName("Route_Length");
            entity.Property(e => e.RouteName)
                .HasMaxLength(255)
                .HasColumnName("Route_Name");
            entity.Property(e => e.StartingPoint)
                .HasMaxLength(255)
                .HasColumnName("Starting_Point");
        });

        modelBuilder.Entity<RouteSection>(entity =>
        {
            entity.HasKey(e => e.RouteSectionId).HasName("PRIMARY");

            entity.ToTable("Route_Section");

            entity.HasIndex(e => e.RoadNumber, "Road_Number");

            entity.HasIndex(e => e.RouteNumber, "Route_Number");

            entity.Property(e => e.RouteSectionId).HasColumnName("Route_Section_ID");
            entity.Property(e => e.RoadNumber).HasColumnName("Road_Number");
            entity.Property(e => e.RouteNumber).HasColumnName("Route_Number");

            entity.HasOne(d => d.RoadNumberNavigation).WithMany(p => p.RouteSections)
                .HasForeignKey(d => d.RoadNumber)
                .HasConstraintName("route_section_ibfk_2");

            entity.HasOne(d => d.RouteNumberNavigation).WithMany(p => p.RouteSections)
                .HasForeignKey(d => d.RouteNumber)
                .HasConstraintName("route_section_ibfk_1");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PRIMARY");

            entity.ToTable("Transport");

            entity.Property(e => e.TransportId).HasColumnName("Transport_ID");
            entity.Property(e => e.AverageFuelConsumption)
                .HasPrecision(10, 2)
                .HasColumnName("Average_Fuel_Consumption");
            entity.Property(e => e.BodyVolume)
                .HasPrecision(10, 2)
                .HasColumnName("body_volume");
            entity.Property(e => e.Brand).HasMaxLength(255);
            entity.Property(e => e.LicensePlate)
                .HasMaxLength(255)
                .HasColumnName("License_Plate");
            entity.Property(e => e.Model).HasMaxLength(255);
            entity.Property(e => e.YearOfRelease).HasColumnName("year_of_release");
        });

        modelBuilder.Entity<TransportExpense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PRIMARY");

            entity.ToTable("Transport_Expenses");

            entity.HasIndex(e => e.WaybillId, "Waybill_ID");

            entity.Property(e => e.ExpenseId).HasColumnName("Expense_ID");
            entity.Property(e => e.ForcedDowntime)
                .HasPrecision(10, 2)
                .HasColumnName("Forced_Downtime");
            entity.Property(e => e.Fuel).HasPrecision(10, 2);
            entity.Property(e => e.LossesDueToDowntime)
                .HasPrecision(10, 2)
                .HasColumnName("Losses_due_to_Downtime");
            entity.Property(e => e.MaintenanceAndRepair)
                .HasPrecision(10, 2)
                .HasColumnName("Maintenance_and_Repair");
            entity.Property(e => e.WaybillId).HasColumnName("Waybill_ID");

            entity.HasOne(d => d.Waybill).WithMany(p => p.TransportExpenses)
                .HasForeignKey(d => d.WaybillId)
                .HasConstraintName("fk_transport_expenses_waybill");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.Property(e => e.UserId).HasColumnName("User_ID");
            entity.Property(e => e.ActualResidentialAddress)
                .HasMaxLength(255)
                .HasColumnName("Actual_Residential_Address");
            entity.Property(e => e.DateOfBirth).HasColumnName("date_of_birth");
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .HasColumnName("First_Name");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.PassportSeriesAndNumber)
                .HasMaxLength(255)
                .HasColumnName("Passport_Series_and_Number");
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Patronymic).HasMaxLength(255);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .HasColumnName("Phone_Number");
            entity.Property(e => e.PlaceOfResidence)
                .HasMaxLength(255)
                .HasColumnName("Place_of_Residence");
            entity.Property(e => e.Position).HasMaxLength(255);
            entity.Property(e => e.Status).HasMaxLength(10);
        });

        modelBuilder.Entity<Waybill>(entity =>
        {
            entity.HasKey(e => e.WaybillId).HasName("PRIMARY");

            entity.ToTable("Waybill");

            entity.HasIndex(e => e.CargoNumber, "Cargo_Number");

            entity.HasIndex(e => e.DriverNumber, "Driver_Number");

            entity.HasIndex(e => e.RouteNumber, "Route_Number");

            entity.HasIndex(e => e.TransportNumber, "Transport_Number");

            entity.HasIndex(e => e.UserNumber, "User_Number");

            entity.Property(e => e.WaybillId).HasColumnName("Waybill_ID");
            entity.Property(e => e.ArrivalDate).HasColumnName("Arrival_Date");
            entity.Property(e => e.CargoNumber).HasColumnName("Cargo_Number");
            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.DepartureDate).HasColumnName("Departure_Date");
            entity.Property(e => e.DriverNumber).HasColumnName("Driver_Number");
            entity.Property(e => e.Photo).HasColumnType("blob");
            entity.Property(e => e.RouteNumber).HasColumnName("Route_Number");
            entity.Property(e => e.Status).HasMaxLength(15);
            entity.Property(e => e.TransportNumber).HasColumnName("Transport_Number");
            entity.Property(e => e.UserNumber).HasColumnName("User_Number");

            entity.HasOne(d => d.CargoNumberNavigation).WithMany(p => p.Waybills)
                .HasForeignKey(d => d.CargoNumber)
                .HasConstraintName("waybill_ibfk_4");

            entity.HasOne(d => d.DriverNumberNavigation).WithMany(p => p.Waybills)
                .HasForeignKey(d => d.DriverNumber)
                .HasConstraintName("waybill_ibfk_1");

            entity.HasOne(d => d.RouteNumberNavigation).WithMany(p => p.Waybills)
                .HasForeignKey(d => d.RouteNumber)
                .HasConstraintName("waybill_ibfk_3");

            entity.HasOne(d => d.TransportNumberNavigation).WithMany(p => p.Waybills)
                .HasForeignKey(d => d.TransportNumber)
                .HasConstraintName("waybill_ibfk_2");

            entity.HasOne(d => d.UserNumberNavigation).WithMany(p => p.Waybills)
                .HasForeignKey(d => d.UserNumber)
                .HasConstraintName("waybill_ibfk_5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
