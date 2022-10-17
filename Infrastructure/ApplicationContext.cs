using Domain.EntitiesForManagement;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class ApplicationContext : DbContext
{
    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }
    public virtual DbSet<Apartment> Apartments { get; set; }
    public virtual DbSet<Area> Areas { get; set; }
    public virtual DbSet<Bill> Bills { get; set; }
    public virtual DbSet<Building?> Buildings { get; set; }
    public virtual DbSet<Contract> Contracts { get; set; }
    public virtual DbSet<ContractHistory> ContractHistories { get; set; }
    public virtual DbSet<Expense> Expenses { get; set; }
    public virtual DbSet<ExpenseType> ExpenseTypes { get; set; }
    public virtual DbSet<ExpenseHistory> ExpenseHistories { get; set; }
    public virtual DbSet<Feedback> Feedbacks { get; set; }
    public virtual DbSet<FeedbackType> FeedbackTypes { get; set; }
    public virtual DbSet<Flat> Flats { get; set; }
    public virtual DbSet<FlatType> FlatTypes { get; set; }
    public virtual DbSet<Invoice> Invoices { get; set; }
    public virtual DbSet<InvoiceHistory> InvoiceHistories { get; set; }
    public virtual DbSet<Major> Majors { get; set; }
    public virtual DbSet<Order> Orders { get; set; }
    public virtual DbSet<OrderDetail> OrderDetails { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<PaymentType> PaymentType { get; set; }
    public virtual DbSet<Renter> Renters { get; set; }
    public virtual DbSet<Request> Requests { get; set; }
    public virtual DbSet<RequestType> RequestTypes { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<ServiceEntity> Services { get; set; }
    public virtual DbSet<ServiceType> ServiceTypes { get; set; }
    public virtual DbSet<University> University { get; set; }
    public virtual DbSet<Wallet> Wallets { get; set; } = null!;
    public virtual DbSet<WalletType> WalletTypes { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
        }

        optionsBuilder.EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId)
                .HasColumnName("WalletID")
                .HasDefaultValueSql("(newid())");

            entity.Property(e => e.AccountId).HasColumnName("AccountID");

            entity.Property(e => e.CreatedDate).HasDefaultValueSql("(getdate())");

            entity.Property(e => e.WalletTypeId).HasColumnName("WalletTypeID");
        });

        modelBuilder.Entity<WalletType>(entity =>
        {
            entity.ToTable("WalletType");

            entity.Property(e => e.WalletTypeId).HasColumnName("WalletTypeID");

            entity.Property(e => e.WalletTypeName).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    private void OnModelCreatingPartial(ModelBuilder modelBuilder)
    {
    }
}