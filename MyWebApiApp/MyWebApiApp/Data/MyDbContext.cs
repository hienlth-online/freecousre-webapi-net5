using Microsoft.EntityFrameworkCore;

namespace MyWebApiApp.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region Dbset
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Category> Categories { get; set; }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>(e =>
            {
                e.ToTable("Transaction");
                e.HasKey(tr => tr.transaction_id);
                e.HasOne<User>(us => us.user)
                    .WithMany(u => u.transactions)
                    .HasForeignKey(tr => tr.user_id);

                e.HasOne<Category>(c => c.category)
                    .WithMany(ca => ca.transactions)
                    .HasForeignKey(tr => tr.category_id);

                e.HasOne<Type>(t => t.type)
                    .WithMany(ty => ty.transactions)
                    .HasForeignKey(tr => tr.type_id);

                e.Property(tr => tr.type_id).IsRequired();
            });

            modelBuilder.Entity<User>(e =>
            {
                e.ToTable("User");
                e.HasKey(u => u.user_id);
                e.HasMany<Transaction>(u => u.transactions)
                    .WithOne(tr => tr.user)
                    .HasForeignKey(tr => tr.user_id);
            });

            modelBuilder.Entity<Type>(e =>
            {
                e.HasKey(t => t.type_id);
                e.HasMany<Transaction>(t => t.transactions)
                    .WithOne(tr => tr.type)
                    .HasForeignKey(tr => tr.type_id);
            });

            modelBuilder.Entity<Category>(e =>
            {
                e.HasKey(ca => ca.category_id);
                e.HasMany<Transaction>(ca => ca.transactions)
                    .WithOne(tr => tr.category)
                    .HasForeignKey(tr => tr.category_id);
            });
        }
    }
}
