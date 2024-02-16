using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace InternetBank.Data
{
    public class ApplicationDbConext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
    {
        public DbSet<ApplicationUser> User { get; set; }
        public DbSet<Account> Account { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public ApplicationDbConext(DbContextOptions<ApplicationDbConext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserLogin<int>>().HasKey(login => new { login.LoginProvider, login.ProviderKey });
            builder.Entity<IdentityUserRole<int>>().HasKey(p => new { p.UserId, p.RoleId });
            builder.Entity<IdentityUserToken<int>>().HasKey(ut => new { ut.UserId, ut.LoginProvider, ut.Name });

            builder.Entity<Transaction>()
                   .HasOne(b => b.Account)
                   .WithMany(a => a.Transactions)
                   .HasForeignKey(b => b.AccountId);

            builder.Entity<Account>()
                   .HasOne(b => b.ApplicationUser)
                   .WithMany(a => a.Accounts)
                   .HasForeignKey(b => b.UserId);
        }
    }
}