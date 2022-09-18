using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    //public virtual DbSet<Address> Address { get; set; }
    public virtual DbSet<Building> BuildingForRent { get; set; }
    public virtual DbSet<Contract> Contract { get; set; }
    public virtual DbSet<ContractHistory> ContractHistory { get; set; }
    public virtual DbSet<Payment> Payment { get; set; }
    public virtual DbSet<PaymentType> PaymentType { get; set; }
    public virtual DbSet<Role> Role { get; set; }
    public virtual DbSet<Room> Room { get; set; }
    public virtual DbSet<RoomType> RoomType { get; set; }
    public virtual DbSet<Transaction> Transaction { get; set; }
    public virtual DbSet<University> University { get; set; }
    public virtual DbSet<RentEntity> RentEntity { get; set; }
    public virtual DbSet<Owner> Owner { get; set; }
    public virtual DbSet<City> City { get; set; }
    public virtual DbSet<District> District { get; set; }
    public virtual DbSet<Ward> Ward { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //throw new NotImplementedException();
    }

    private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
        //throw new NotImplementedException();
    }
}