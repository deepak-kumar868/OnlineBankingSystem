using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace DALayer.Models
{
    public partial class OnlineBankingSystemContext : DbContext
    {
        public OnlineBankingSystemContext()
        {
        }

        public OnlineBankingSystemContext(DbContextOptions<OnlineBankingSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountType> AccountTypes { get; set; }
        public virtual DbSet<Loan> Loans { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UserCredential> UserCredentials { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LIN25004626\\SQLEXPRESS ; Database=OnlineBankingSystem; Trusted_Connection=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AI");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Accounts__8CB286B90DFF0713");

                entity.HasIndex(e => e.AccountNo, "UQ__Accounts__B19EBB637A5ADBDE")
                    .IsUnique();

                entity.Property(e => e.CustomerId)
                    .ValueGeneratedNever()
                    .HasColumnName("Customer_ID");

                entity.Property(e => e.AccountNo)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_no");

                entity.Property(e => e.AccountTypeId).HasColumnName("Account_Type_id");

                entity.Property(e => e.Branch)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerAddress)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Address");

                entity.Property(e => e.CustomerAge).HasColumnName("Customer_Age");

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Name");

                entity.Property(e => e.CustomerPhNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Customer_Ph_No");

                entity.Property(e => e.CustomerType)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Ifsc)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("IFSC");

                entity.HasOne(d => d.AccountType)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.AccountTypeId)
                    .HasConstraintName("FK__Accounts__Accoun__70DDC3D8");
            });

            modelBuilder.Entity<AccountType>(entity =>
            {
                entity.ToTable("AccountType");

                entity.Property(e => e.AccountTypeId)
                    .ValueGeneratedNever()
                    .HasColumnName("Account_Type_id");

                entity.Property(e => e.AccountTyp)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Account_Typ");

                entity.Property(e => e.MinBalance).HasColumnName("Min_Balance");

                entity.Property(e => e.TransactionLimit).HasColumnName("Transaction_limit");
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

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.LoanAccountNoNavigations)
                    .HasPrincipalKey(p => p.AccountNo)
                    .HasForeignKey(d => d.AccountNo)
                    .HasConstraintName("FK__Loan__Account_no__06CD04F7");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.LoanCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Loan__Customer_I__05D8E0BE");
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

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithMany(p => p.TransactionAccountNoNavigations)
                    .HasPrincipalKey(p => p.AccountNo)
                    .HasForeignKey(d => d.AccountNo)
                    .HasConstraintName("FK__Transacti__Accou__7F2BE32F");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.TransactionCustomers)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Transacti__Custo__7E37BEF6");
            });

            modelBuilder.Entity<UserCredential>(entity =>
            {
                entity.HasKey(e => e.UserName)
                    .HasName("PK__UserCred__C9F28457145E805C");

                entity.HasIndex(e => e.AccountNo, "UQ__UserCred__349D9DFC3443275D")
                    .IsUnique();

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AccountNo)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.MobileNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AccountNoNavigation)
                    .WithOne(p => p.UserCredential)
                    .HasPrincipalKey<Account>(p => p.AccountNo)
                    .HasForeignKey<UserCredential>(d => d.AccountNo)
                    .HasConstraintName("FK__UserCrede__Accou__0A9D95DB");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
