using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Kyrsach
{
    public partial class CursachContext : DbContext
    {
        public CursachContext()
        {
        }

        public CursachContext(DbContextOptions<CursachContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CurrencyList> CurrencyList { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<TransactionsList> Transactions_List { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http: //go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.EnableSensitiveDataLogging()
                    .UseSqlServer("Server=HOME-PC;Database=Cursach;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyList>(entity =>
            {
                entity.HasKey(e => e.IdCurrency)
                    .HasName("PK_CURRENCY_LIST");

                entity.ToTable("Currency_list");

                entity.Property(e => e.IdCurrency)
                    .HasColumnName("ID_Currency")
                    .ValueGeneratedNever();

                entity.Property(e => e.Abbrecitation)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.ExplorerSite)
                    .HasColumnName("Explorer_site")
                    ;

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TokenSite)
                    .HasColumnName("Token_site")
                    ;
            });

            modelBuilder.Entity<Tokens>(entity =>
            {
                entity.HasKey(e => e.Adres)
                    .HasName("PK_Tokens");

                entity.Property(e => e.Adres)
                    .HasColumnName("Adres")
                    ;
                ;

                entity.Property(e => e.Balance);

                entity.Property(e => e.IdCurrency).HasColumnName("ID_Currency");

                entity.Property(e => e.IdWallet).HasColumnName("ID_wallet").HasColumnType("int");

                entity.Property(e => e.TxLsit)
                    .HasColumnName("Tx_lsit")
                    ;

                entity.HasOne(d => d.IdCurrencyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Tokens_fk0");

                entity.HasOne(d => d.IdWalletNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdWallet)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tokens_User");
            });

            modelBuilder.Entity<TransactionsList>(entity =>
            {
                entity.HasKey(e => e.TxHash)
                    .HasName("PK_Transactions_list")
                    ;

                //entity.ToTable("Transactions_list");

                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Fee).HasColumnType("money");

                entity.Property(e => e.FromAdress)
                    .HasColumnName("From_adress");

                entity.Property(e => e.IdCurrency).HasColumnName("ID_Currency");

                entity.Property(e => e.ToAdress)
                    .HasColumnName("To_adress");

                entity.Property(e => e.TxHash)
                    .HasColumnName("Tx_hash");

                entity.Property(e => e.UsdPrice)
                    .HasColumnName("USD_price")
                    .HasColumnType("money");

                entity.HasOne(d => d.IdCurrencyNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.IdCurrency)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Transaction_fk0");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK_USER");

                entity.Property(e => e.IdUser)
                    .HasColumnName("ID_user")
                    .ValueGeneratedNever();

                entity.Property(e => e.Mail)
                    .IsRequired()
                    .HasColumnType("varchar")
                    .HasMaxLength(254);

                entity.Property(e => e.Mnemomic)
                    .IsRequired();

                entity.Property(e => e.Password)
                    .IsRequired()
                    ;

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasColumnName("User_name")
                    .HasMaxLength(50)
                    .HasDefaultValueSql("('User')");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}