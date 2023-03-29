using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DAL.Models
{
    public partial class OnlineBankingContext : DbContext
    {
        public OnlineBankingContext()
        {
        }

        public OnlineBankingContext(DbContextOptions<OnlineBankingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN80018294\\SQLEXPRESS; Database=OnlineBanking; Trusted_Connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.AccountNo)
                    .HasName("PK__Accounts__B19EBB62AF56AE78");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_id");

                entity.Property(e => e.Branch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK__Accounts__Accoun__2A4B4B5E");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Accounts__Custom__29572725");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_id");

                entity.Property(e => e.AccountTyp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_Typ");

                entity.Property(e => e.MinBalance).HasColumnName("Min_Balance");

                entity.Property(e => e.TransactionLimit).HasColumnName("Transaction_limit");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Address");

                entity.Property(e => e.CustomerAge).HasColumnName("Customer_Age");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPhNo).HasColumnName("Customer_Ph_No");

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");
            });

            modelBuilder.Entity<Loan>(entity =>
            {
                entity.ToTable("Loan");

                entity.Property(e => e.LoanId).HasColumnName("Loan_id");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_ID");

                entity.Property(e => e.LoanAmount).HasColumnName("Loan_Amount");

                entity.Property(e => e.LoanStatus)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Loan_Status");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.AccountNo)
                    .HasConstraintName("FK__Loan__Account_no__31EC6D26");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Loans)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Loan__Customer_I__30F848ED");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.Property(e => e.TransactionId).HasColumnName("Transaction_id");

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.CustomerId).HasColumnName("Customer_id");

                entity.Property(e => e.DateOfTransaction)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_of_Transaction");

                entity.Property(e => e.TransactionStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Transaction_Status");

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountNo)
                    .HasConstraintName("FK__Transacti__Accou__35BCFE0A");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__Custo__34C8D9D1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
